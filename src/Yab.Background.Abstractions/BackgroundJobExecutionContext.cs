using System;
using Yab.DependencyInjection;

namespace Yab.Background
{
    /// <summary>
    /// 后台任务之执行上下文
    /// </summary>
    public class BackgroundJobExecutionContext : IServiceProviderAccessor
    {
        /// <summary>
        /// 服务提供者
        /// </summary>
        public IServiceProvider ServiceProvider { get; }

        /// <summary>
        /// 任务类型
        /// </summary>
        public Type JobType { get; }

        /// <summary>
        /// 任务参数
        /// </summary>
        public object JobArgs { get; }

        public BackgroundJobExecutionContext(IServiceProvider serviceProvider, Type jobType, object jobArgs)
        {
            ServiceProvider = serviceProvider;
            JobType = jobType;
            JobArgs = jobArgs;
        }
    }
}
