using System;
using System.Collections.Generic;
using System.Reflection;

namespace Yab.Modularity
{
    /// <summary>
    /// 模块描述接口
    /// </summary>
    public interface IModuleDescriptor
    {
        /// <summary>
        /// 模块类型
        /// </summary>
        Type Type { get; }

        /// <summary>
        /// 模块程序集
        /// </summary>
        Assembly Assembly { get; }

        /// <summary>
        /// 模块实例
        /// </summary>
        IModule Instance { get; }

        /// <summary>
        /// 是否作为插件载入
        /// </summary>
        bool IsLoadedAsPlugin { get; }

        /// <summary>
        /// 引用的模块集合
        /// </summary>
        IReadOnlyList<IModuleDescriptor> Dependencies { get; }
    }
}
