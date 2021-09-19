using System;

namespace Yab.Background
{
    /// <summary>
    /// 后台任务信息
    /// </summary>
    public class BackgroundJobInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public virtual string JobName { get; set; }

        /// <summary>
        /// 参数（已序列化）
        /// </summary>
        public virtual string JobArgs { get; set; }

        /// <summary>
        /// 重试次数
        /// </summary>
        public virtual short TryCount { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreationTime { get; set; }

        /// <summary>
        /// 下次执行时间
        /// </summary>
        public virtual DateTime NextTryTime { get; set; }

        /// <summary>
        /// 上次执行时间
        /// </summary>
        public virtual DateTime? LastTryTime { get; set; }

        /// <summary>
        /// 是否已放弃
        /// </summary>
        public virtual bool IsAbandoned { get; set; }

        /// <summary>
        /// 优先级
        /// </summary>
        public virtual BackgroundJobPriority Priority { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BackgroundJobInfo()
        {
            Priority = BackgroundJobPriority.Normal;
        }
    }
}
