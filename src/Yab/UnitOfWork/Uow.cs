using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Yab.DependencyInjection;

namespace Yab.UnitOfWork
{
    public class Uow : IUow, ITransientDependency
    {
        public event EventHandler<UowFailedEventArgs> Failed;
        public event EventHandler<UowEventArgs> Disposed;

        private readonly Dictionary<string, IDatabaseApi> _databaseApis;
        private readonly Dictionary<string, ITransactionApi> _transactionApis;

        private Exception _exception;
        private bool _isCompleting;
        private bool _isRollbacked;

        protected List<Func<Task>> CompletedHandlers { get; } = new List<Func<Task>>();

        public Guid Id { get; } = Guid.NewGuid();

        public IServiceProvider ServiceProvider { get; }

        public IDictionary<string, object> Items { get; }

        public UowOptions Options { get; private set; }

        public IUow Outer { get; private set; }

        public string ReservationName { get; private set; }

        public bool IsReserved { get; private set; }

        public bool IsDisposed { get; private set; }

        public bool IsCompleted { get; private set; }

        public Uow(IServiceProvider serviceProvider)
        {
            _databaseApis = new Dictionary<string, IDatabaseApi>();
            _transactionApis = new Dictionary<string, ITransactionApi>();

            ServiceProvider = serviceProvider;
            Items = new Dictionary<string, object>();
        }

        protected virtual IReadOnlyList<IDatabaseApi> GetAllActiveDatabaseApis()
        {
            return _databaseApis.Values.ToImmutableList();
        }

        protected virtual IReadOnlyList<ITransactionApi> GetAllActiveTransactionApis()
        {
            return _transactionApis.Values.ToImmutableList();
        }

        protected virtual async Task CommitAllAsync()
        {
            foreach (var transaction in GetAllActiveTransactionApis())
            {
                await transaction.CommitAsync();
            }
        }

        protected virtual async Task RollbackAllAsync(CancellationToken cancellationToken)
        {
            foreach (var databaseApi in GetAllActiveDatabaseApis())
            {
                if (databaseApi is ISupportsRollback)
                {
                    try
                    {
                        await (databaseApi as ISupportsRollback).RollbackAsync(cancellationToken);
                    }
                    catch { }
                }
            }

            foreach (var transactionApi in GetAllActiveTransactionApis())
            {
                if (transactionApi is ISupportsRollback)
                {
                    try
                    {
                        await (transactionApi as ISupportsRollback).RollbackAsync(cancellationToken);
                    }
                    catch { }
                }
            }
        }

        protected virtual async Task HandleOnCompletedAsync()
        {
            foreach (var handler in CompletedHandlers)
            {
                await handler.Invoke();
            }
        }

        protected virtual void OnFailed()
        {
            Failed?.Invoke(this, new UowFailedEventArgs(this, _exception, _isRollbacked));
        }

        protected virtual void OnDisposed()
        {
            Disposed?.Invoke(this, new UowEventArgs(this));
        }

        protected void DisposeAll()
        {
            foreach (var transactionApi in GetAllActiveTransactionApis())
            {
                try
                {
                    transactionApi.Dispose();
                }
                catch
                { }
            }
        }

        public void Initialize(UowOptions options)
        {
            if (Options != null)
                throw new YabException("该工作单元已被初始化过");

            Check.NotNull(options, nameof(options));

            Options = options;
            IsReserved = false;
        }

        public virtual void SetOuter(IUow outer)
        {
            Check.NotNull(outer, nameof(outer));

            Outer = outer;
        }

        public virtual void Reserve(string reservationName)
        {
            Check.NotNull(reservationName, nameof(reservationName));

            ReservationName = reservationName;
            IsReserved = true;
        }

        public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            if (_isRollbacked)
                return;

            foreach (var databaseApi in GetAllActiveDatabaseApis())
            {
                if (databaseApi is ISupportsSaveChanges)
                {
                    await (databaseApi as ISupportsSaveChanges).SaveChangesAsync(cancellationToken);
                }
            }
        }

        public virtual async Task CompleteAsync(CancellationToken cancellationToken = default)
        {
            if (_isRollbacked)
                return;

            if (_isCompleting)
                throw new YabException("该工作单元正在执行");

            if (IsCompleted)
                throw new YabException("该工作单元已执行完成");

            try
            {
                _isCompleting = true;
                await SaveChangesAsync(cancellationToken);
                await CommitAllAsync();
                IsCompleted = true;
                await HandleOnCompletedAsync();
            }
            catch (Exception ex)
            {
                _exception = ex;
                throw;
            }
        }

        public virtual async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            if (_isRollbacked)
                return;

            _isRollbacked = true;
            await RollbackAllAsync(cancellationToken);
        }

        public void OnCompleted(Func<Task> handler)
        {
            CompletedHandlers.Add(handler);
        }

        public void AddDatabaseApi(string key, IDatabaseApi api)
        {
            Check.NotNull(key, nameof(key));
            Check.NotNull(api, nameof(api));

            if (_databaseApis.ContainsKey(key))
                throw new YabException("There is already a database API in this unit of work with given key: " + key);

            _databaseApis.Add(key, api);
        }

        public IDatabaseApi FindDatabaseApi(string key)
        {
            throw new NotImplementedException();
        }

        public IDatabaseApi GetOrAddDatabaseApi(string key, Func<IDatabaseApi> factory)
        {
            throw new NotImplementedException();
        }

        public void AddTransactionApi(string key, ITransactionApi api)
        {
            throw new NotImplementedException();
        }

        public ITransactionApi FindTransactionApi(string key)
        {
            throw new NotImplementedException();
        }

        public ITransactionApi GetOrAddTransactionApi(string key, Func<ITransactionApi> factory)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (IsDisposed)
                return;

            IsDisposed = true;
            DisposeAll();

            if (!IsCompleted || _exception != null)
            {
                OnFailed();
            }

            OnDisposed();
        }

        public override string ToString()
        {
            return $"[工作单元:{Id}]";
        }
    }
}
