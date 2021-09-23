using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Yab.Modularity
{
    /// <summary>
    /// 程序配置服务之上下文
    /// </summary>
    public class AppServiceConfigurationContext
    {
        /// <summary>
        /// 服务集合
        /// </summary>
        public IServiceCollection Services { get; }

        /// <summary>
        /// 其他项
        /// </summary>
        public IDictionary<string, object> Items { get; }

        public AppServiceConfigurationContext(IServiceCollection services)
        {
            Services = Check.NotNull(services, nameof(services));
            Items = new Dictionary<string, object>();
        }

        public object this[string key]
        {
            get => Items.GetOrDefault(key);
            set => Items[key] = value;
        }
    }
}
