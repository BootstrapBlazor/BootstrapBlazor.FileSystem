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