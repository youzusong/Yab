using System;

namespace Yab.DependencyInjection
{
    /// <summary>
    /// 依赖提供者接口
    /// </summary>
    public interface IDependencyProvider
    {
        /// <summary>
        /// 获取依赖类型
        /// </summary>
        /// <returns></returns>
        Type[] GetDependedTypes();
    }
}
