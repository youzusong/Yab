using System.Threading.Tasks;

namespace Yab.Message.Sms
{
    /// <summary>
    /// 短信发送接口
    /// </summary>
    public interface ISmsSender
    {
        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="smsMessage">短信</param>
        /// <returns></returns>
        Task SendAsync(SmsMessage smsMessage);
    }
}
