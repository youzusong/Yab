namespace Yab.Background
{
    /// <summary>
    /// 后台任务优先级
    /// </summary>
    public enum BackgroundJobPriority : byte
    {
        /// <summary>
        /// 低
        /// </summary>
        Low = 10,

        /// <summary>
        /// 中低
        /// </summary>
        BelowNormal = 15,

        /// <summary>
        /// 中
        /// </summary>
        Normal = 20,

        /// <summary>
        /// 中高
        /// </summary>
        AboveNormal = 25,

        /// <summary>
        /// 高
        /// </summary>
        High = 30
    }
}
