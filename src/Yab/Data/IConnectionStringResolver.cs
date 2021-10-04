using System.Threading.Tasks;

namespace Yab.Data
{
    /// <summary>
    /// 
    /// </summary>
    public interface IConnectionStringResolver
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionStringName"></param>
        /// <returns></returns>
        Task<string> ResolveAsync(string connectionStringName = null);
    }
}
