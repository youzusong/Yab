using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Yab.Background
{
    public class YabBackgroundJobOptions
    {
        private readonly Dictionary<string, BackgroundJobConfiguration> _jobConfigsByJobName;
        private readonly Dictionary<Type, BackgroundJobConfiguration> _jobConfigsByArgsType;

        public bool IsEnabled { get; set; } = true;

        public YabBackgroundJobOptions()
        {
            _jobConfigsByJobName = new Dictionary<string, BackgroundJobConfiguration>();
            _jobConfigsByArgsType = new Dictionary<Type, BackgroundJobConfiguration>();
        }

        public BackgroundJobConfiguration GetJob(Type argsType)
        {
            var jobConfiguration = _jobConfigsByArgsType.GetOrDefault(argsType);
            if (jobConfiguration == null)
                throw new YabException($"未找到后台任务，参数类型：{argsType.AssemblyQualifiedName}");

            return jobConfiguration;
        }

        public BackgroundJobConfiguration GetJob(string jobName)
        {
            var jobConfiguration = _jobConfigsByJobName.GetOrDefault(jobName);
            if (jobConfiguration == null)
                throw new YabException($"未找到后台任务，任务名称：{jobName}");

            return jobConfiguration;
        }

        public IReadOnlyList<BackgroundJobConfiguration> GetJobs()
        {
            return _jobConfigsByArgsType.Values.ToImmutableList();
        }

        public void AddJob<TJob>()
        {
            AddJob(typeof(TJob));
        }

        public void AddJob(Type jobType)
        {
            AddJob(new BackgroundJobConfiguration(jobType));
        }

        public void AddJob(BackgroundJobConfiguration jobConfiguration)
        {
            _jobConfigsByJobName[jobConfiguration.JobName] = jobConfiguration;
            _jobConfigsByArgsType[jobConfiguration.ArgsType] = jobConfiguration;
        }
    }
}
