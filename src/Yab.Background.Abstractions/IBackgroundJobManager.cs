using System;
using System.Threading.Tasks;

namespace Yab.Background
{
    /// <summary>
    /// 后台任务之管理者接口
    /// </summary>
    public interface IBackgroundJobManager
    {
        /// <summary>
        /// 任务入队
        /// </summary>
        /// <typeparam name="TArgs"></typeparam>
        /// <param name="args">任务参数</param>
        /// <param name="priority">任务优先级</param>
        /// <param name="delay">延时执行时间</param>
        /// <returns>任务ID</returns>
        Task<string> EnqueueAsync<TArgs>(
            TArgs args,
            BackgroundJobPriority priority = BackgroundJobPriority.Normal,
            TimeSpan? delay = null
        );
    }
}
