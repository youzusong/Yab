using System;
using System.Collections.Generic;

namespace Yab.DependencyInjection
{
    public class DefaultCachedServiceProvider : ICachedServiceProvider, IScopedDependency
    {
        protected IServiceProvider ServiceProvider { get; }

        protected IDictionary<Type, object> CachedServices { get; }

        public DefaultCachedServiceProvider(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            CachedServices = new Dictionary<Type, object>
            {
                {typeof(IServiceProvider), serviceProvider}
            };
        }

        public object GetService(Type serviceType)
        {
            return CachedServices.GetOrAdd(serviceType, () => ServiceProvider.GetService(serviceType));
        }
    }
}
