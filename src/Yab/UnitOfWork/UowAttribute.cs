using System;
using System.Data;

namespace Yab.UnitOfWork
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Interface)]
    public class UowAttribute : Attribute
    {
        public bool IsDisabled { get; set; }

        public bool IsTransactional { get; set; }

        public IsolationLevel? IsolationLevel { get; set; }

        public int? Timeout { get; set; }

        public UowAttribute()
        { }

        public UowAttribute(bool isTransactional)
        {
            IsTransactional = isTransactional;
        }

        public UowAttribute(bool isTransactional, IsolationLevel isolationLevel)
        {
            IsTransactional = isTransactional;
            IsolationLevel = isolationLevel;
        }

        public UowAttribute(bool isTransactional, IsolationLevel isolationLevel, int timeout)
        {
            IsTransactional = isTransactional;
            IsolationLevel = isolationLevel;
            Timeout = timeout;
        }
    }
}
