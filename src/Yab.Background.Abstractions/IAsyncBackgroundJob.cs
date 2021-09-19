using System.Threading.Tasks;

namespace Yab.Background
{
    /// <summary>
    /// (异步)后台任务接口
    /// </summary>
    /// <typeparam name="TArgs"></typeparam>
    public interface IAsyncBackgroundJob<in TArgs>
    {
        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        Task ExecuteAsync(TArgs args);
    }
}
