using System;

namespace Yab.DDD.Domain
{
    public class YabEntityNotFoundException : Exception
    {
        public Type EntityType { get; }

        public Object EntityKey { get; set; }

        public YabEntityNotFoundException(Type entityType, object entityKey)
        {
            EntityType = entityType;
            EntityKey = entityKey;
        }

    }
}
