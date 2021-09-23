using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Yab.Modularity.Plugins
{
    /// <summary>
    /// 插件源集合
    /// </summary>
    public class PluginSourceList : List<IPluginSource>
    {
        /// <summary>
        /// 获取所有模块
        /// </summary>
        /// <param name="logger"></param>
        /// <returns></returns>
        public Type[] GetAllModules(ILogger logger)
        {
            return this
                .SelectMany(pluginSource => pluginSource.GetModulesWithAllDependencies(logger))
                .Distinct()
                .ToArray();
        }
    }
}
