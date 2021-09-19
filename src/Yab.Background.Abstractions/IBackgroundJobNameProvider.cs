namespace Yab.Background
{
    /// <summary>
    /// 后台任务之名称提供者接口
    /// </summary>
    public interface IBackgroundJobNameProvider
    {
        /// <summary>
        /// 任务名称
        /// </summary>
        string Name { get; }
    }
}
