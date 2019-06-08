﻿using Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicGarden.Http;

namespace MusicGarden.Source
{
    public class BaiduSource : IMusicSource
    {
        static HttpConfig DEFAULT_CONFIG = new HttpConfig
        {
            Referer = "http://music.baidu.com/",

        };

        public string Name { get; } = "百度";


        public List<Song> SearchSongs(string keyword, int page, int pageSize)
        {
            var searchResult = HttpHelper.GET(string.Format("http://musicapi.qianqian.com/v1/restserver/ting?query={0}&method=baidu.ting.search.common&format=json&page_no={1}&page_size={2}", keyword, page, pageSize), DEFAULT_CONFIG);
            var result = new List<Song>();
            try
            {
                var searchResultJson = JsonParser.Deserialize(searchResult).song_list;//反序列化JSON
                var songIds = new List<string>();

                foreach (var item in searchResultJson)
                {
                    songIds.Add(item["song_id"]);
                }

                var songIdsStr = string.Join(",", songIds.ToArray());

                var songInfos = HttpHelper.GET(string.Format("http://music.taihe.com/data/music/links?songIds={0}", songIdsStr), DEFAULT_CONFIG);
                var songList = JObject.Parse(songInfos)["data"]["songList"];//解析JSON数据

                var index = 1;
                foreach (var songItem in songList)
                {
                    var song = new Song
                    {
                        id = (string)songItem["queryId"],
                        name = (string)songItem["songName"],
                        singer = (string)songItem["artistName"],
                        album = (string)songItem["albumName"],
                        rate = 128,
                        index = index++,
                        size = (double)songItem["size"],
                        source = Name,
                        url = (string)songItem["songLink"],
                        duration = (double)songItem["time"]
                    };

                    result.Add(song);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return result;

        }

        public string getDownloadUrl(Song song)
        {
            return song.url;

        }

    }
}
