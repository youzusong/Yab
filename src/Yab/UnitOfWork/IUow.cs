using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Yab.DependencyInjection;

namespace Yab.UnitOfWork
{
    /// <summary>
    /// 工作单元接口
    /// </summary>
    public interface IUow : IDatabaseApiContainer, ITransactionApiContainer, IServiceProviderAccessor, IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        event EventHandler<UowFailedEventArgs> Failed;

        /// <summary>
        /// 
        /// </summary>
        event EventHandler<UowEventArgs> Disposed;

        /// <summary>
        /// 
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// 
        /// </summary>
        IDictionary<string, object> Items { get; }

        /// <summary>
        /// 
        /// </summary>
        UowOptions Options { get; }

        /// <summary>
        /// 
        /// </summary>
        IUow Outer { get; }

        /// <summary>
        /// 
        /// </summary>
        string ReservationName { get; }

        /// <summary>
        /// 
        /// </summary>
        bool IsReserved { get; }

        /// <summary>
        /// 
        /// </summary>
        bool IsDisposed { get; }

        /// <summary>
        /// 
        /// </summary>
        bool IsCompleted { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outer"></param>
        void SetOuter(IUow outer);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        void Initialize(UowOptions options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reservationName"></param>
        void Reserve(string reservationName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task CompleteAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task RollbackAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handler"></param>
        void OnCompleted(Func<Task> handler);
    }
}
