using Microsoft.Extensions.DependencyInjection;
using System;
using Yab.Modularity.Plugins;

namespace Yab.Modularity
{
    /// <summary>
    /// 模块加载器接口
    /// </summary>
    public interface IModuleLoader
    {
        /// <summary>
        /// 加载模块
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="startupModuleType">启动模块</param>
        /// <param name="pluginSources">插件源集合</param>
        /// <returns></returns>
        IModuleDescriptor[] LoadModules(
            IServiceCollection services,
            Type startupModuleType,
            PluginSourceList pluginSources
        );
    }
}
