using Yab.Threading;

namespace Yab.Background
{
    /// <summary>
    /// 后台工作者之管理者接口
    /// </summary>
    public interface IBackgroundWorkerManager : IRunnable
    {
        /// <summary>
        /// 添加工作者
        /// </summary>
        /// <param name="worker">工作者</param>
        void Add(IBackgroundWorker worker);
    }
}
