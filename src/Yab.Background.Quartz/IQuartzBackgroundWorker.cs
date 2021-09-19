using Quartz;
using System;
using System.Threading.Tasks;

namespace Yab.Background.Quartz
{
    /// <summary>
    /// Quartz后台工作者接口
    /// </summary>
    public interface IQuartzBackgroundWorker : IBackgroundWorker, IJob
    {
        /// <summary>
        /// 触发器
        /// </summary>
        ITrigger Trigger { get; set; }

        /// <summary>
        /// 工作详情
        /// </summary>
        IJobDetail JobDetail { get; set; }

        /// <summary>
        /// 自动注册
        /// </summary>
        bool AutoRegister { get; set; }

        /// <summary>
        /// 排程工作
        /// </summary>
        Func<IScheduler, Task> ScheduleJob { get; set; }
    }
}
