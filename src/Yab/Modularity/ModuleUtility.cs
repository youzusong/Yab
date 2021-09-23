using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Yab.DependencyInjection;

namespace Yab.Modularity
{
    public static class ModuleUtility
    {
        /// <summary>
        /// 判断是否为模块类型
        /// </summary>
        /// <param name="moduleType"></param>
        /// <returns></returns>
        internal static bool IsModule(Type moduleType)
        {
            var typeInfo = moduleType.GetTypeInfo();

            return
                typeInfo.IsClass &&
                !typeInfo.IsAbstract &&
                !typeInfo.IsGenericType &&
                typeof(IModule).IsAssignableFrom(moduleType);
        }

        /// <summary>
        /// 检查模块类型
        /// </summary>
        /// <param name="moduleType"></param>
        internal static void CheckModuleType(Type moduleType)
        {
            if (!IsModule(moduleType))
                throw new ArgumentException($"类型并非Module：[{moduleType.AssemblyQualifiedName}]");
        }

        /// <summary>
        /// 递归加载引用的模块
        /// </summary>
        /// <param name="moduleTypes"></param>
        /// <param name="moduleType"></param>
        /// <param name="logger"></param>
        /// <param name="depth"></param>
        private static void AddModuleAndDependenciesRecursively(
            List<Type> moduleTypes,
            Type moduleType,
            ILogger logger,
            int depth = 0)
        {
            CheckModuleType(moduleType);

            if (moduleTypes.Contains(moduleType))
                return;

            moduleTypes.Add(moduleType);
            logger.Log(LogLevel.Debug, $"{new string(' ', depth * 2)} - {moduleType.FullName}");

            foreach (var dependedModuleType in FindDependedModuleTypes(moduleType))
            {
                AddModuleAndDependenciesRecursively(moduleTypes, dependedModuleType, logger, depth + 1);
            }
        }

        /// <summary>
        /// 查找引用的模块类型
        /// </summary>
        /// <param name="moduleType"></param>
        /// <returns></returns>
        public static List<Type> FindDependedModuleTypes(Type moduleType)
        {
            CheckModuleType(moduleType);

            var dependencies = new List<Type>();
            var dependencyProviders = moduleType
                .GetCustomAttributes()
                .OfType<IDependencyProvider>();

            foreach (var descriptor in dependencyProviders)
            {
                foreach (var dependedModuleType in descriptor.GetDependedTypes())
                {
                    dependencies.AddIfNotContains(dependedModuleType);
                }
            }

            return dependencies;
        }

        /// <summary>
        /// 查找所有模块类型
        /// </summary>
        /// <param name="startupModuleType"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        public static List<Type> FindAllModuleTypes(Type startupModuleType, ILogger logger)
        {
            var moduleTypes = new List<Type>();
            logger.Log(LogLevel.Debug, "已加载模块：");
            AddModuleAndDependenciesRecursively(moduleTypes, startupModuleType, logger);
            return moduleTypes;
        }

    }
}
