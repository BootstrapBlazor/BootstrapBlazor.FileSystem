// ********************************** 
// Densen Informatica 中讯科技 
// 作者：Alex Chow
// e-mail:zhouchuanglin@gmail.com 
// **********************************

using BootstrapBlazor.FileSystem.Services;
using Microsoft.JSInterop;

namespace BootstrapBlazor.FileSystem.Services
{

    public class FileSystemService: BaseService<string>
    { 

        public async Task<List<string>> OpenFilePicker()
        {
            msg = "Azure Cognitive Services Computer Vision - .NET quickstart example";
            await GetStatus(msg);
            var res = new List<string>();
            return res; 

        }

    }
}

