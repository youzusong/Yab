using System.Threading;

namespace Yab.Threading
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICancellationTokenProvider
    {
        /// <summary>
        /// 
        /// </summary>
        CancellationToken Token { get; }
    }
}
