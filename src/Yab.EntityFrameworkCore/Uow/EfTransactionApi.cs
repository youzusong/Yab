using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Yab.Threading;
using Yab.UnitOfWork;

namespace Yab.EntityFrameworkCore.Uow
{
    public class EfTransactionApi : ITransactionApi, ISupportsRollback
    {
        public IDbContextTransaction DbContextTransaction { get; }

        public DbContext StarterDbContext { get; }

        public List<DbContext> AttendedDbContexts { get; }

        protected ICancellationTokenProvider CancellationTokenProvider { get; }

        public EfTransactionApi(
            IDbContextTransaction dbContextTransaction,
            DbContext starterDbContext,
            ICancellationTokenProvider cancellationTokenProvider)
        {
            DbContextTransaction = dbContextTransaction;
            StarterDbContext = starterDbContext;
            CancellationTokenProvider = cancellationTokenProvider;
            AttendedDbContexts = new List<DbContext>();
        }

        /// <summary>
        /// 是否为使用同一连接的关系型数据库
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        private bool IsSameConnectionRelationalDb(DbContext dbContext)
        {
            return
                dbContext.As<DbContext>().HasRelationalTransactionManager() &&
                dbContext.Database.GetDbConnection() == DbContextTransaction.GetDbTransaction().Connection);
        }

        public async Task CommitAsync()
        {
            foreach (var dbContext in AttendedDbContexts)
            {
                // 如果关系型数据库使用同一连接，则使用共享事务
                if (IsSameConnectionRelationalDb(dbContext))
                {
                    continue;
                }

                await dbContext.Database.CommitTransactionAsync(CancellationTokenProvider.Token);
            }

            await DbContextTransaction.CommitAsync(CancellationTokenProvider.Token);
        }

        public async Task RollbackAsync(CancellationToken cancellationToken)
        {
            foreach (var dbContext in AttendedDbContexts)
            {
                // 如果关系型数据库使用同一连接，则使用共享事务
                if (IsSameConnectionRelationalDb(dbContext))
                {
                    continue;
                }

                await dbContext.Database.RollbackTransactionAsync(CancellationTokenProvider.FallbackToProvider(cancellationToken));
            }

            await DbContextTransaction.RollbackAsync(CancellationTokenProvider.FallbackToProvider(cancellationToken));
        }

        public void Dispose()
        {
            DbContextTransaction.Dispose();
        }
    }
}
