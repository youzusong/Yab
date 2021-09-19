using System.Threading;
using System.Threading.Tasks;

namespace Yab.Threading
{
    /// <summary>
    /// 可执行接口
    /// </summary>
    public interface IRunnable
    {
        /// <summary>
        /// 开始
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task StartAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 结束
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task StopAsync(CancellationToken cancellationToken = default);
    }
}
