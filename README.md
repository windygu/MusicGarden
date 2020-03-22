# MusicGarden
MusicGarden是使用VS2015基于WMP组件开发的，兼有搜索下载功能的音乐播放器,~~本项目没有使用数据库~~，仅在Windows10上测试。
<br><br>

## 版本
`master` 分支是最新的所有代码。

想打开软件运行？欢迎查看本仓库的 [Releases](https://github.com/jianyuyanyu/MusicGarden/releases)，

下载软件后，请先全部解压出来，不要丢失文件，也不要在压缩软件中打开，因为部分压缩软件中无法正常运行程序。
如遇安装问题请下载.NET环境及工具，按说明处理。其他操作系统如打不开或者打开报错，则需安装：Microsoft. NET Framework 4.X， 推荐安装[.NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework/thank-you/net48-chs)，下载地址：https://dotnet.microsoft.com/download/dotnet-framework/net48。
<br><br>
欢迎大家对软件进行修改添加新功能，[点击这里可以pull](https://github.com/jianyuyanyu/MusicGarden/pulls)。
<br><br>

## 代码结构说明
[MusicGarden](https://github.com/jianyuyanyu/MusicGarden)
```
│  AboutForm.cs                           //关于窗体类
│  AboutForm.Designer.cs
│  AboutForm.resx
│  App.config
│  Dopamine.ico                           //软件图标文件
│  DownloadForm.cs                        //HTTP帮助类
│  DownloadForm.Designer.cs
│  DownloadForm.resx
│  GaussianBlur.cs                        //高斯模糊类
│  HttpHelper.cs                          //HTTP帮助类
│  IniFile.cs                             //读写ini帮助类
│  LyricFile.cs                           //音乐歌词类
│  MusicForm.cs                           //软件主窗体类
│  MusicForm.Designer.cs
│  MusicForm.resx
│  MusicGarden.csproj                     //项目解决方案文件
│  MusicGarden.csproj.user
│  packages.config
│  Program.cs
│  SetForm.cs                             //软件设置窗体类
│  SetForm.Designer.cs
│  SetForm.resx
│  SongInfoForm.cs                        //音乐信息窗体类
│  SongInfoForm.Designer.cs
│  SongInfoForm.resx
│  Songs.cs                               //音乐类
│  TaskbarManager.cs                      //任务栏状态类
│  
│              
├─Http                                    //下载帮助类
│      Song.cs             
│      SongDownloader.cs
│      WebClient.cs
│      
├─Properties                               //项目属性文件夹
│      app.manifest
│      AssemblyInfo.cs
│      Resources.Designer.cs
│      Resources.resx
│      Settings.Designer.cs
│      Settings.settings
│      
├─Resources                                 //资源文件夹
│      
└─Source
        BaiduSource.cs                      //百度音乐源
        IMusicSource.cs                     //音乐源接口
        KugouSource.cs                      //酷狗音乐源
        KuwoSourse.cs                       //酷我音乐源
        MusicSources.cs                     //音乐源聚合
        NeteaseSource.cs                    //网易音乐源
        QQSource.cs                         //QQ音乐源
        
```
