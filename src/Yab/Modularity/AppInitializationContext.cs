using System;
using Yab.DependencyInjection;

namespace Yab.Modularity
{
    /// <summary>
    /// 程序初始化之上下文
    /// </summary>
    public class AppInitializationContext : IServiceProviderAccessor
    {
        public IServiceProvider ServiceProvider { get; set; }

        public AppInitializationContext(IServiceProvider serviceProvider)
        {
            Check.NotNull(serviceProvider, nameof(serviceProvider));

            ServiceProvider = serviceProvider;
        }
    }
}
