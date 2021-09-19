namespace Yab.Message.Sms.Aliyun
{
    public class YabAliyunSmsOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public string AccessKeySecret { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AccessKeyId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string EndPoint { get; set; }

        public YabAliyunSmsOptions()
        {
            EndPoint = "dysmsapi.aliyuncs.com";
        }
    }
}
