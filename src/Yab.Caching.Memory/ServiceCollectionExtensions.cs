using Yab.Caching;
using Yab.Caching.Memory;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMemoryCacheManager(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ILocalCacheManager, MemoryCacheManager>();
            return services;
        }
    }
}
