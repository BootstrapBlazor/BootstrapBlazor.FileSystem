// ********************************** 
// Densen Informatica 中讯科技 
// 作者：Alex Chow
// e-mail:zhouchuanglin@gmail.com 
// **********************************

using BootstrapBlazor.FileSystem.Services; 

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// OCR 服务扩展类
    /// </summary>
    public static class FileSystemServiceCollectionExtensions
    {

        /// <summary>
        /// 增加 OCR 服务扩展类,<para></para>
        /// </summary>
        /// <param name="services"></param>
        /// <param name="key"></param>
        /// <param name="url"></param> 
        /// <returns></returns>
        public static IServiceCollection AddFileSystemExtensions(this IServiceCollection services)
        {
            services.AddTransient<FileSystemService>();
            return services;
        }

    }

}
