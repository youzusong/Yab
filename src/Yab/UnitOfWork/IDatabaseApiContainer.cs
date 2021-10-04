using System;

namespace Yab.UnitOfWork
{
    public interface IDatabaseApiContainer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="api"></param>
        void AddDatabaseApi(string key, IDatabaseApi api);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        IDatabaseApi FindDatabaseApi(string key);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        IDatabaseApi GetOrAddDatabaseApi(string key, Func<IDatabaseApi> factory);
    }
}
