using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Yab.UnitOfWork;

namespace Yab.EntityFrameworkCore.Uow
{
    public class EfDatabaseApi : IDatabaseApi, ISupportsSaveChanges
    {
        public DbContext DbContext { get; }

        public EfDatabaseApi(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
