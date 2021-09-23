using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Yab.Modularity.Plugins
{
    public static class PluginSourceExtensions
    {
        /// <summary>
        /// 获取所有引用的模块
        /// </summary>
        /// <param name="plugInSource"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        public static Type[] GetModulesWithAllDependencies(this IPluginSource plugInSource, ILogger logger)
        {
            Check.NotNull(plugInSource, nameof(plugInSource));

            return plugInSource
                .GetModules()
                .SelectMany(type => ModuleUtility.FindAllModuleTypes(type, logger))
                .Distinct()
                .ToArray();
        }
    }
}
