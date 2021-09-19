namespace Yab.Background.Quartz
{
    /// <summary>
    ///  Quartz后台工作者之适配器接口
    /// </summary>
    public interface IQuartzBackgroundWorkerAdapter : IQuartzBackgroundWorker
    {
        /// <summary>
        /// 创建工作者
        /// </summary>
        /// <param name="worker"></param>
        void BuildWorker(IBackgroundWorker worker);
    }
}
