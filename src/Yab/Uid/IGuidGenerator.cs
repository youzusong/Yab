using System;

namespace Yab.Uid
{
    /// <summary>
    /// GUID产生器接口
    /// </summary>
    public interface IGuidGenerator
    {
        /// <summary>
        /// 创建ID
        /// </summary>
        /// <returns></returns>
        Guid Create();
    }
}
