namespace Yab.Background.Quartz
{
    public static class YasQuartzBackgroundConsts
    {
        public const string JobDataPrefix = "Yab.QuazrtJob.";
        public const string JobRetryIndexKey = JobDataPrefix + "RetryIndex";
        public const string JobRetryCountKey = JobDataPrefix + "RetryCount";
        public const string JobRetryIntervalTimeKey = JobDataPrefix + "RetryIntervalTime";
    }
}
