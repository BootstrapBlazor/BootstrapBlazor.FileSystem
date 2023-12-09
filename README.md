# Blazor File System Access 文件系统访问 组件 

## Web 应用程序与用户本地设备上的文件进行交互

File System Access API（以前称为 Native File System API，在此之前称为 Writeable Files API）使开发人员能够构建强大的 Web 应用程序，与用户本地设备上的文件进行交互，例如 IDE、照片和视频编辑器、文本编辑器等。用户授予 Web 应用访问权限后，此 API 允许他们直接读取或保存对用户设备上文件和文件夹的更改。除了读取和写入文件之外，文件系统访问 API 还提供打开目录和枚举其内容的能力。

浏览器支持：

chrome 86 | firfox × | edge 86 | safari ×

Windows、macOS、ChromeOS 和 Linux 上的大多数 Chromium 浏览器目前都支持文件系统访问 API

示例:

https://blazor.app1.es/FileSystem

使用方法:

1.nuget包

```BootstrapBlazor.FileSystem```

2._Imports.razor 文件 或者页面添加 添加组件库引用

```@using BootstrapBlazor.Components```


3.razor页面
```
<FileSystem OnFileText="OnFileText" 
            OnFileStream="OnFileStream" 
            OnDirectory="OnDirectory" 
            />

<pre>@contents</pre>

```
```
@code{

    private string contents;

    private Task OnFileText(string contents)
    {
        this.contents = contents;
        StateHasChanged();
        return Task.CompletedTask;
    }
    
    private Task OnFileStream(Stream stream)
    {
        //using MiniExcelLibs
        //private string contentsExcel;
        //var rows = stream.Query().ToList();
        //rows.ForEach(a=> contentsExcel += Environment.NewLine + string.Join(" | " , a ));
        StateHasChanged();
        return Task.CompletedTask;
    }
    
    private Task OnDirectory(List<string> dirs)
    {
        if (dirs == null || !dirs.Any()) return Task.CompletedTask;
        contents += "Dir:" + Environment.NewLine;
        contents += dirs.First() + Environment.NewLine;
        foreach (var item in dirs.Skip(1).OrderByDescending(a => a.StartsWith("+")).ThenBy(a => a))
        {
            contents += item + Environment.NewLine;
        }
        StateHasChanged();
        return Task.CompletedTask;
    }


} 
```


---
#### Blazor 组件

[条码扫描 ZXingBlazor](https://www.nuget.org/packages/ZXingBlazor#readme-body-tab)
[![nuget](https://img.shields.io/nuget/v/ZXingBlazor.svg?style=flat-square)](https://www.nuget.org/packages/ZXingBlazor) 
[![stats](https://img.shields.io/nuget/dt/ZXingBlazor.svg?style=flat-square)](https://www.nuget.org/stats/packages/ZXingBlazor?groupby=Version)

[图片浏览器 Viewer](https://www.nuget.org/packages/BootstrapBlazor.Viewer#readme-body-tab)

[手写签名 SignaturePad](https://www.nuget.org/packages/BootstrapBlazor.SignaturePad#readme-body-tab)

[定位/持续定位 Geolocation](https://www.nuget.org/packages/BootstrapBlazor.Geolocation#readme-body-tab)

[屏幕键盘 OnScreenKeyboard](https://www.nuget.org/packages/BootstrapBlazor.OnScreenKeyboard#readme-body-tab)

[百度地图 BaiduMap](https://www.nuget.org/packages/BootstrapBlazor.BaiduMap#readme-body-tab)

[谷歌地图 GoogleMap](https://www.nuget.org/packages/BootstrapBlazor.Maps#readme-body-tab)

[蓝牙和打印 Bluetooth](https://www.nuget.org/packages/BootstrapBlazor.Bluetooth#readme-body-tab)

[PDF阅读器 PdfReader](https://www.nuget.org/packages/BootstrapBlazor.PdfReader#readme-body-tab)

[文件系统访问 FileSystem](https://www.nuget.org/packages/BootstrapBlazor.FileSystem#readme-body-tab)

[光学字符识别 OCR](https://www.nuget.org/packages/BootstrapBlazor.OCR#readme-body-tab)

[电池信息/网络信息 WebAPI](https://www.nuget.org/packages/BootstrapBlazor.WebAPI#readme-body-tab)

[文件预览 FileViewer](https://www.nuget.org/packages/BootstrapBlazor.FileViewer#readme-body-tab)

[视频播放器 VideoPlayer](https://www.nuget.org/packages/BootstrapBlazor.VideoPlayer#readme-body-tab)

[图像裁剪 ImageCropper](https://www.nuget.org/packages/BootstrapBlazor.ImageCropper#readme-body-tab)

[视频播放器 BarcodeGenerator](https://www.nuget.org/packages/BootstrapBlazor.BarcodeGenerator#readme-body-tab)

#### AlexChow

[今日头条](https://www.toutiao.com/c/user/token/MS4wLjABAAAAGMBzlmgJx0rytwH08AEEY8F0wIVXB2soJXXdUP3ohAE/?) | [博客园](https://www.cnblogs.com/densen2014) | [知乎](https://www.zhihu.com/people/alex-chow-54) | [Gitee](https://gitee.com/densen2014) | [GitHub](https://github.com/densen2014)
