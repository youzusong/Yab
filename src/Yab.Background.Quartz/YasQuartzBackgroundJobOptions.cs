using Quartz;
using System;
using System.Threading.Tasks;

namespace Yab.Background.Quartz
{
    /// <summary>
    /// Quartz后台任务配置项
    /// </summary>
    public class YasQuartzBackgroundJobOptions
    {
        /// <summary>
        /// 重试次数
        /// </summary>
        public int RetryCount { get; set; }

        /// <summary>
        /// 重试间隔时间
        /// </summary>
        public int RetryIntervalTime { get; set; }

        /// <summary>
        /// 重试操作
        /// </summary>
        public Func<int, IJobExecutionContext, JobExecutionException, Task> RetryStrategy { get; set; }

        public YasQuartzBackgroundJobOptions()
        {
            RetryCount = 3;
            RetryIntervalTime = 3600;
            RetryStrategy = DefaultRetryStrategy;
        }

        private async Task DefaultRetryStrategy(int retryIndex, IJobExecutionContext executionContext, JobExecutionException exception)
        {
            exception.RefireImmediately = true;

            // 如果超出重试次数，则取消所有触发器，并禁止重试
            var retryCount = executionContext.JobDetail.JobDataMap.GetInt(YasQuartzBackgroundConsts.JobRetryCountKey);
            if (retryIndex > retryCount)
            {
                exception.RefireImmediately = false;
                exception.UnscheduleAllTriggers = true;
                return;
            }

            var retryIntervalTime = executionContext.JobDetail.JobDataMap.GetInt(YasQuartzBackgroundConsts.JobRetryIntervalTimeKey);
            await Task.Delay(retryIntervalTime);
        }
    }
}
