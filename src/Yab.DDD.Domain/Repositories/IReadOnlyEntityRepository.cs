using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Yab.DDD.Domain.Entities;

namespace Yab.DDD.Domain.Repositories
{
    public interface IReadOnlyEntityRepository<TEntity> : IRepository
        where TEntity : class, IEntity
    {
        Task<long> GetCountAsync(CancellationToken cancellationToken = default);

        Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken = default);

        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        Task<List<TEntity>> GetPagedListAsync(
            int pageIndex,
            int pageSize,
            string sortBy,
            bool sortAsc = true,
            CancellationToken cancellationToken = default);
    }

    public interface IReadOnlyEntityRepository<TEntity, TKey> : IReadOnlyEntityRepository<TEntity>
        where TEntity : class, IEntity<TKey>
    {
        Task<TEntity> FindAsync(TKey id, CancellationToken cancellationToken = default);

        Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken = default);
    }
}
