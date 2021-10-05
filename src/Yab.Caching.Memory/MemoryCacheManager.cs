using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace Yab.Caching.Memory
{
    public class MemoryCacheManager : ILocalCacheManager
    {
        private readonly IMemoryCache _cache;

        public MemoryCacheManager(IMemoryCache cache)
        {
            _cache = cache;
        }

        public T Get<T>(string key)
        {
            var data = _cache.Get<T>(key);
            if (data == null) return default(T);
            return data;
        }

        public Task<T> GetAsync<T>(string key)
        {
            var data = Task.Run(() => Get<T>(key));
            return data;
        }

        public void Set<T>(string key, T value, TimeSpan? expireTime)
        {
            if (expireTime.HasValue)
                _cache.Set(key, value, expireTime.Value);
            else
                _cache.Set(key, value);
        }

        public Task SetAsync<T>(string key, T value, TimeSpan? expireTime)
        {
            Task.Run(() => Set<T>(key, value, expireTime));
            return Task.CompletedTask;
        }

        public void Remove<T>(string key)
        {
            _cache.Remove(key);
        }

        public Task RemoveAsync<T>(string key)
        {
            Task.Run(() => Remove<T>(key));
            return Task.CompletedTask;
        }

    }
}
