using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Yab.DDD.Domain.Entities;

namespace Yab.DDD.Domain.Repositories
{
    public interface IEntityRepository<TEntity> : IReadOnlyEntityRepository<TEntity>
        where TEntity : class, IEntity
    {
        Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        Task InsertManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default);

        Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        Task UpdateManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default);

        Task DeleteAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        Task DeleteManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default);
    }

    public interface IEntityRepository<TEntity, TKey> : IEntityRepository<TEntity>, IReadOnlyEntityRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        Task DeleteAsync(TKey id, bool autoSave = false, CancellationToken cancellationToken = default);

        Task DeleteManyAsync(IEnumerable<TKey> ids, bool autoSave = false, CancellationToken cancellationToken = default);
    }
}
