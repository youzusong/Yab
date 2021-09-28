namespace Yab.DDD.Domain.Entities
{
    /// <summary>
    /// 实体接口
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// 获取主键
        /// </summary>
        /// <returns></returns>
        object[] GetKeys();
    }

    /// <summary>
    /// 实体接口
    /// </summary>
    /// <typeparam name="TKey">主键类型</typeparam>
    public interface IEntity<TKey> : IEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        TKey Id { get; }
    }

}
