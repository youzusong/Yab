using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Yab.EntityFrameworkCore
{
    /// <summary>
    /// EF数据库上下文提供者接口
    /// </summary>
    public interface IEfDbContextProvider<TDbContext>
        where TDbContext : DbContext
    {
        Task<TDbContext> GetDbContextAsync();
    }
}
