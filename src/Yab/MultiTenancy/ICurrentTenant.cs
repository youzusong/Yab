using System;

namespace Yab.MultiTenancy
{
    /// <summary>
    /// 当前租户接口
    /// </summary>
    public interface ICurrentTenant
    {
        /// <summary>
        /// 是否可用
        /// </summary>
        bool IsAvailable { get; }

        /// <summary>
        /// 租户名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 变更租户
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IDisposable Change(string name);
    }
}
