using System;

namespace Yab.DDD.Domain.Entities
{
    /// <summary>
    /// 实体基类
    /// </summary>
    [Serializable]
    public abstract class Entity : IEntity
    {
        public abstract object[] GetKeys();
    }

    /// <summary>
    /// 实体基类
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    [Serializable]
    public abstract class Entity<TKey> : Entity, IEntity<TKey>
    {
        public virtual TKey Id { get; protected set; }

        protected Entity()
        { }

        protected Entity(TKey id)
        {
            Id = id;
        }

        public override object[] GetKeys()
        {
            return new object[] { Id };
        }
    }
}
