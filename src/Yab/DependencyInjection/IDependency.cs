namespace Yab.DependencyInjection
{
    /// <summary>
    /// 依赖接口(瞬时)
    /// </summary>
    public interface ITransientDependency
    { }

    /// <summary>
    /// 依赖接口(范围)
    /// </summary>
    public interface IScopedDependency
    { }

    /// <summary>
    /// 依赖接口(单例)
    /// </summary>
    public interface ISingletonDependency
    { }
}
