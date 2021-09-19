using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Yab.DependencyInjection
{
    /// <summary>
    /// 依赖注册器接口
    /// </summary>
    public interface IDependencyRegistrar
    {
        /// <summary>
        /// 添加程序集
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assembly"></param>
        void AddAssembly(IServiceCollection services, Assembly assembly);

        /// <summary>
        /// 添加类型
        /// </summary>
        /// <param name="services"></param>
        /// <param name="types"></param>
        void AddTypes(IServiceCollection services, params Type[] types);

        /// <summary>
        /// 添加类型
        /// </summary>
        /// <param name="services"></param>
        /// <param name="type"></param>
        void AddType(IServiceCollection services, Type type);
    }
}
