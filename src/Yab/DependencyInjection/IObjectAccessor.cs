namespace Yab.DependencyInjection
{
    /// <summary>
    /// 对象之访问器接口
    /// </summary>
    public interface IObjectAccessor<out T>
    {
        /// <summary>
        /// 对象值
        /// </summary>
        T Value { get; }
    }
}
