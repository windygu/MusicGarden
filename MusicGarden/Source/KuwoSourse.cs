using System;
using System.Collections.Generic;
using MusicGarden.Http;
using System.Threading.Tasks;
using Json;
using Newtonsoft.Json.Linq;

namespace MusicGarden.Source
{
   public  class KuwoSourse : IMusicSource
    {
        static HttpConfig DEFAULT_CONFIG = new HttpConfig
        {
            Referer = " http://www.kuwo.cn/",
        };

        public string Name { get; } = "酷我";

        public List<Song> SearchSongs(string keyword, int page, int pageSize)//泛型集合
        {
            var searchResult = HttpHelper.GET(string.Format("http://search.kuwo.cn/r.s?all={0}&encoding=utf8&ft=music&itemset=web_2013&client=kt&pn=0&rn=10&rformat=json&encoding=utf8[1]&rn=[2]&rformat=json&encoding=utf8", keyword, page, pageSize), DEFAULT_CONFIG);

            var result = new List<Song>();
            try
            {
                //var searchResultJson = JsonParser.Deserialize(searchResult).song_list;
                //var songIds = new List<string>();
                
                
                var songList = JObject.Parse(searchResult)["abslist"];//解析JSON数据

                var index = 1;
                foreach (var songItem in songList)
                {
                    var song = new Song
                    {
                        id = (string)songItem["MUSICRID"],
                        name = (string)songItem["SONGNAME"],
                        singer = (string)songItem["ARTIST"],
                        album = (string)songItem["ALBUM"],
                        rate = 320,
                        index = index++,
                     
                        source = Name,
                        duration = (double)songItem["DURATION"]
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
            
            var musicUrl = HttpHelper.GET(string.Format(" http://antiserver.kuwo.cn/anti.s?type=convert_url&rid={0}&format=mp3&response=url", song.id), DEFAULT_CONFIG);
            return musicUrl;

        }
    }
}
