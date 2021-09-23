using System;

namespace Yab.Modularity.Plugins
{
    /// <summary>
    /// 插件源接口
    /// </summary>
    public interface IPluginSource
    {
        /// <summary>
        /// 获取模块
        /// </summary>
        /// <returns></returns>
        Type[] GetModules();
    }
}
