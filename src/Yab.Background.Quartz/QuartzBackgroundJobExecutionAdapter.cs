using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Quartz;
using System;
using System.Threading.Tasks;
using Yab.Serialization.Json;

namespace Yab.Background.Quartz
{
    /// <summary>
    /// Quartz后台任务之适配器
    /// </summary>
    public class QuartzBackgroundJobExecutionAdapter<TArgs> : IJob
    {
        public ILogger<QuartzBackgroundJobExecutionAdapter<TArgs>> Logger { get; set; }

        protected YabBackgroundJobOptions Options { get; }
        protected YasQuartzBackgroundJobOptions QuartzOptions { get; }
        protected IServiceScopeFactory ServiceScopeFactory { get; }
        protected IBackgroundJobExecuter JobExecuter { get; }
        protected IJsonSerializer JsonSerializer { get; }

        public QuartzBackgroundJobExecutionAdapter(
            IOptions<YabBackgroundJobOptions> options,
            IOptions<YasQuartzBackgroundJobOptions> quartzOptions,
            IBackgroundJobExecuter jobExecuter,
            IServiceScopeFactory serviceScopeFactory,
            IJsonSerializer jsonSerializer,
            ILogger<QuartzBackgroundJobExecutionAdapter<TArgs>> logger)
        {
            Options = options.Value;
            QuartzOptions = quartzOptions.Value;
            JobExecuter = jobExecuter;
            ServiceScopeFactory = serviceScopeFactory;
            JsonSerializer = jsonSerializer;
            Logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using (var scope = ServiceScopeFactory.CreateScope())
            {
                var jobArgs = JsonSerializer.Deserialize<TArgs>(context.JobDetail.JobDataMap.GetString(nameof(TArgs)));
                var jobType = Options.GetJob(typeof(TArgs)).JobType;
                var jobContext = new BackgroundJobExecutionContext(scope.ServiceProvider, jobType, jobArgs);
                try
                {
                    await JobExecuter.ExecuteAsync(jobContext);
                }
                catch (Exception exception)
                {
                    var jobExecutionException = new JobExecutionException(exception);
                    var retryIndexKey = YasQuartzBackgroundConsts.JobRetryIndexKey;
                    var retryIndex = context.JobDetail.JobDataMap.GetInt(retryIndexKey);
                    retryIndex++;
                    context.JobDetail.JobDataMap.Put(retryIndexKey, retryIndex.ToString());

                    await QuartzOptions.RetryStrategy.Invoke(retryIndex, context, jobExecutionException);

                    throw jobExecutionException;
                }
            }
        }
    }
}
