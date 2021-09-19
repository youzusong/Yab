using System;

namespace Yab.Background
{
    /// <summary>
    /// 后台任务配置
    /// </summary>
    public class BackgroundJobConfiguration
    {
        /// <summary>
        /// 参数类型
        /// </summary>
        public Type ArgsType { get; }

        /// <summary>
        /// 任务类型
        /// </summary>
        public Type JobType { get; }

        /// <summary>
        /// 任务名称
        /// </summary>
        public string JobName { get; }

        public BackgroundJobConfiguration(Type jobType)
        {
            JobType = jobType;
            ArgsType = BackgroundJobUtility.GetArgsType(jobType);
            JobName = BackgroundJobUtility.GetJobName(ArgsType);
        }
    }
}
