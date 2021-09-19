using System.Threading.Tasks;

namespace Yab.Background
{
    /// <summary>
    /// 后台任务之执行者接口
    /// </summary>
    public interface IBackgroundJobExecuter
    {
        /// <summary>
        /// 执行任务
        /// </summary>
        /// <param name="contextz">上下文</param>
        /// <returns></returns>
        Task ExecuteAsync(BackgroundJobExecutionContext contextz);
    }
}
