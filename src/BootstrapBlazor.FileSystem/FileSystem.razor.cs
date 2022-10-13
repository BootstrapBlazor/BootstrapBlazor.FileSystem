// ********************************** 
// Densen Informatica 中讯科技 
// 作者：Alex Chow
// e-mail:zhouchuanglin@gmail.com 
// **********************************

using BootstrapBlazor.FileSystem.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Reflection;

namespace BootstrapBlazor.Components;

//https://developer.mozilla.org/en-US/docs/Web/API/File_System_Access_API
//https://web.dev/file-system-access/

/// <summary>
/// 文件系统访问 File System Access 组件基类
/// </summary>
public partial class FileSystem : IAsyncDisposable
{
    [Inject] IJSRuntime? JS { get; set; }
    private IJSObjectReference? module;
    private DotNetObjectReference<FileSystem>? instance { get; set; }
    [Inject] FileSystemService? FileSystemService { get; set; }
    public string? msg = string.Empty;

    protected string FileText = "";

    protected FileSystemHandle? FileHandle;
    private Task HandleOnChange(ChangeEventArgs args)
    {
        FileText = args?.Value?.ToString()??"";
        return Task.CompletedTask;
    }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        try
        {
            if (firstRender)
            {
                module = await JS!.InvokeAsync<IJSObjectReference>("import", "./_content/BootstrapBlazor.FileSystem/api.js");
                instance = DotNetObjectReference.Create(this);
            }
        }
        catch (Exception e)
        {
            msg += e.Message + Environment.NewLine;
            if (OnError != null) await OnError.Invoke(e.Message);
        }
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        if (module is not null)
        {
            await module.DisposeAsync();
        }
    }


    public virtual async Task NewFile()
    {
        try
        {
            //指定建议的文件名
            //文件内容
            FileHandle = await module!.InvokeAsync<FileSystemHandle>("newFile",  Guid.NewGuid().ToString() + ".txt",  Guid.NewGuid().ToString() );
            FileText = FileHandle.contents??"";
            msg += FileHandle.status + ":" + FileHandle?.name + " => " + FileText  + Environment.NewLine;
        }
        catch (Exception e)
        {
            msg += e.Message + Environment.NewLine;
            if (OnError != null) await OnError.Invoke(e.Message);
        }
    }

    public virtual async Task SaveFile()
    {
        try
        {
            FileHandle = await module!.InvokeAsync<FileSystemHandle>("saveFile", FileText );
            msg += FileHandle.status + ":" + FileHandle?.name + Environment.NewLine;
        }
        catch (Exception e)
        {
            msg += e.Message + Environment.NewLine;
            if (OnError != null) await OnError.Invoke(e.Message);
        }
    }

    /// <summary>
    /// 打开文件
    /// </summary>
    public virtual async Task GetFile()
    {
        try
        {
            FileHandle = await module!.InvokeAsync<FileSystemHandle>("GetFile", instance);
            FileText = FileHandle?.contents ?? "";
            msg += FileHandle?.status + ":" + FileHandle?.name + " => " + FileText + Environment.NewLine;
        }
        catch (Exception e)
        {
            msg += e.Message + Environment.NewLine;
            if (OnError != null) await OnError.Invoke(e.Message);
        }
    }

    /// <summary>
    /// 获取电量
    /// </summary>
    public virtual async Task GetDir()
    {
        try
        {
            var dirs = await module!.InvokeAsync<List<string>>("GetDir");
            msg += "Dir:" + Environment.NewLine;
            if (dirs == null || !dirs.Any()) return;
            msg += dirs.First() + Environment.NewLine;
            foreach (var item in dirs.Skip(1).OrderByDescending(a=>a.StartsWith ("+")).ThenBy(a => a))
            {
                msg += item + Environment.NewLine;
            }
        }
        catch (Exception e)
        {
            msg += e.Message + Environment.NewLine;
            if (OnError != null) await OnError.Invoke(e.Message);
        }
    }

    /// <summary>
    /// 获得/设置 错误回调方法
    /// </summary>
    [Parameter]
    public Func<string, Task>? OnError { get; set; }

    /// <summary>
    /// 获得/设置 电池信息回调方法
    /// </summary>
    [Parameter]
    public Func<FileInfo, Task>? OnFileResult { get; set; }

    /// <summary>
    /// 获取电池信息完成回调方法
    /// </summary> 
    /// <returns></returns>
    [JSInvokable]
    public async Task GetFileResult(FileInfo fileData)
    {
        try
        {
            msg += fileData.name + Environment.NewLine;
            Console.WriteLine(fileData.name);
            if (OnFileResult != null) await OnFileResult.Invoke(fileData);
        }
        catch (Exception e)
        {
            msg += e.Message + Environment.NewLine;
            if (OnError != null) await OnError.Invoke(e.Message);
        }
    }

    /// <summary>
    /// 获取电量
    /// </summary>
    public virtual async Task VerifyPermission()
    {
        try
        {
            var result = await module!.InvokeAsync<bool>("verifyPermission");
            msg += (result ? "授权" : "未授权") + Environment.NewLine;
        }
        catch (Exception e)
        {
            msg += e.Message + Environment.NewLine;
            if (OnError != null) await OnError.Invoke(e.Message);
        }
    }

    /// <summary>
    /// 状态回调方法
    /// </summary> 
    /// <returns></returns>
    [JSInvokable]
    public async Task GetResult(string result, FileSystemHandle? fileHandle)
    {
        try
        {
            Console.WriteLine(result);
            msg += (result) + fileHandle?.name + Environment.NewLine;
            Console.WriteLine(fileHandle?.name);
        }
        catch (Exception e)
        {
            msg += e.Message + Environment.NewLine;
            if (OnError != null) await OnError.Invoke(e.Message);
        }
    }




}
