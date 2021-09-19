namespace Yab.Background
{
    /// <summary>
    /// 后台任务接口
    /// </summary>
    /// <typeparam name="TArgs"></typeparam>
    public interface IBackgroundJob<in TArgs>
    {
        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="args"></param>
        void Execute(TArgs args);
    }
}
