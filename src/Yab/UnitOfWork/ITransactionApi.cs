using System;
using System.Threading.Tasks;

namespace Yab.UnitOfWork
{
    public interface ITransactionApi : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task CommitAsync();
    }
}
