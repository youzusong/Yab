using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;

namespace Yab.Caching.Distributed
{
    public class DistributedCacheManager : ICacheManager
    {
        private readonly IDistributedCache _cache;

        public DistributedCacheManager(IDistributedCache cache)
        {
            _cache = cache;
        }

        public T Get<T>(string key)
        {

            throw new NotImplementedException();
        }

        public Task<T> GetAsync<T>(string key)
        {
            throw new NotImplementedException();
        }

        public void Remove<T>(string key)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync<T>(string key)
        {
            throw new NotImplementedException();
        }

        public void Set<T>(string key, T value, TimeSpan? expireTime = null)
        {
            throw new NotImplementedException();
        }

        public Task SetAsync<T>(string key, T value, TimeSpan? expireTime = null)
        {
            throw new NotImplementedException();
        }
    }
}
