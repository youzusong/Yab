namespace Yab.Background
{
    /// <summary>
    /// 后台任务之执行结果
    /// </summary>
    public class BackgroundJobExecutionResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public string Success { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public bool ErrorMessage { get; set; }
    }
}
