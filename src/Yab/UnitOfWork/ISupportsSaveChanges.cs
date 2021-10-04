using System.Threading;
using System.Threading.Tasks;

namespace Yab.UnitOfWork
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISupportsSaveChanges
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
