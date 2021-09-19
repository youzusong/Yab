using System;
using Yab.DependencyInjection;

namespace Yab.Uid
{
    /// <summary>
    /// 简单GUID产生器
    /// </summary>
    public class SimpleGuidGenerator : IGuidGenerator, ISingletonDependency
    {
        public virtual Guid Create()
        {
            return Guid.NewGuid();
        }
    }
}
