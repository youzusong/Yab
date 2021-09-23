using Microsoft.Extensions.DependencyInjection;
using System;

namespace Yab.Modularity
{
    /// <summary>
    /// 程序接口
    /// </summary>
    public interface IApplication : IModuleContainer, IDisposable
    {
        /// <summary>
        /// 启动模块的类型
        /// </summary>
        Type StartupModuleType { get; }

        /// <summary>
        /// 服务集合
        /// </summary>
        IServiceCollection Services { get; }

        /// <summary>
        /// 服务提供者
        /// </summary>
        IServiceProvider ServiceProvider { get; }

        /// <summary>
        /// 关闭程序
        /// </summary>
        void ShutDown();
    }
}
