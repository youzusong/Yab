using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Yab.DDD.Domain.Entities;
using Yab.DependencyInjection;
using Yab.Uow;

namespace Yab.DDD.Domain.Repositories
{
    public abstract class EntityRepositoryBase<TEntity> : IEntityRepository<TEntity>, IServiceProviderAccessor, IUnitOfWorkEnabled
        where TEntity : class, IEntity
    {
        public IServiceProvider ServiceProvider => throw new NotImplementedException();

        protected EntityRepositoryBase()
        { }

        protected virtual Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public abstract Task<long> GetCountAsync(CancellationToken cancellationToken = default);

        public abstract Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken = default);

        public abstract Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        public abstract Task<List<TEntity>> GetPagedListAsync(int pageIndex, int pageSize, string sortBy, bool sortAsc = true, CancellationToken cancellationToken = default);


        public abstract Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        public virtual async Task InsertManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities)
            {
                await InsertAsync(entity, cancellationToken: cancellationToken);
            }

            if (autoSave)
            {
                await SaveChangesAsync(cancellationToken);
            }
        }

        public abstract Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        public virtual async Task UpdateManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities)
            {
                await UpdateAsync(entity, cancellationToken: cancellationToken);
            }

            if (autoSave)
            {
                await SaveChangesAsync(cancellationToken);
            }
        }

        public abstract Task DeleteAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        public virtual async Task DeleteManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities)
            {
                await DeleteAsync(entity, false, cancellationToken);
            }

            if (autoSave)
            {
                await SaveChangesAsync(cancellationToken);
            }
        }
    }

    public abstract class EntityRepositoryBase<TEntity, TKey> : EntityRepositoryBase<TEntity>, IEntityRepository<TEntity, TKey>
       where TEntity : class, IEntity<TKey>
    {
        public abstract Task<TEntity> FindAsync(TKey id, CancellationToken cancellationToken = default);

        public virtual async Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var entity = await FindAsync(id, cancellationToken);
            if (entity == null)
                throw new YabEntityNotFoundException(typeof(TEntity), id);

            return entity;
        }

        public virtual async Task DeleteAsync(TKey id, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var entity = await FindAsync(id, cancellationToken);
            if (entity == null)
                return;

            await DeleteAsync(entity, autoSave, cancellationToken);
        }

        public virtual async Task DeleteManyAsync(IEnumerable<TKey> ids, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            foreach (var id in ids)
            {
                await DeleteAsync(id, false, cancellationToken);
            }

            if (autoSave)
            {
                await SaveChangesAsync(cancellationToken);
            }
        }
    }
}
