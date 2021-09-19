using Microsoft.Extensions.Options;
using Quartz;
using System;
using System.Threading.Tasks;
using Yab.DependencyInjection;
using Yab.Serialization.Json;

namespace Yab.Background.Quartz
{
    /// <summary>
    /// Quartz后台任务之管理者
    /// </summary>
    [Dependency(ReplaceServices = true)]
    public class QuartzBackgroundJobManager : IBackgroundJobManager, ITransientDependency
    {
        protected IScheduler Scheduler { get; }
        protected IJsonSerializer JsonSerializer { get; }
        protected YasQuartzBackgroundJobOptions Options { get; }

        public QuartzBackgroundJobManager(
            IScheduler scheduler,
            IJsonSerializer jsonSerializer,
            IOptions<YasQuartzBackgroundJobOptions> options)
        {
            Scheduler = scheduler;
            JsonSerializer = jsonSerializer;
            Options = options.Value;
        }

        public virtual async Task<string> EnqueueAsync<TArgs>(
            TArgs args,
            BackgroundJobPriority priority = BackgroundJobPriority.Normal,
            TimeSpan? delay = null)
        {
            return await ReEnqueueAsync(args, Options.RetryCount, Options.RetryIntervalTime, priority, delay);
        }

        public virtual async Task<string> ReEnqueueAsync<TArgs>(
            TArgs args,
            int retryCount,
            int retryIntervalTime,
            BackgroundJobPriority priority = BackgroundJobPriority.Normal,
            TimeSpan? delay = null)
        {
            var jobDataMap = new JobDataMap
            {
                {nameof(TArgs), JsonSerializer.Serialize(args)},
                {YasQuartzBackgroundConsts.JobRetryCountKey, retryCount.ToString()},
                {YasQuartzBackgroundConsts.JobRetryIntervalTimeKey, retryIntervalTime.ToString()},
                {YasQuartzBackgroundConsts.JobRetryIndexKey, "0"}
            };

            var jobDetail = JobBuilder
                .Create<QuartzBackgroundJobExecutionAdapter<TArgs>>()
                .RequestRecovery()
                .SetJobData(jobDataMap)
                .Build();

            var trigger = !delay.HasValue
                ? TriggerBuilder.Create().StartNow().Build()
                : TriggerBuilder.Create().StartAt(new DateTimeOffset(DateTime.Now.Add(delay.Value))).Build();

            await Scheduler.ScheduleJob(jobDetail, trigger);
            return jobDetail.Key.ToString();
        }
    }
}
