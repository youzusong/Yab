using System.Net.Mail;
using System.Threading.Tasks;

namespace Yab.Message.Mail.Smtp
{
    /// <summary>
    /// SMTP邮件发送者接口
    /// </summary>
    public interface ISmtpEmailSender : IEmailSender
    {
        /// <summary>
        /// 建立客户端
        /// </summary>
        /// <returns></returns>
        Task<SmtpClient> BuildClientAsync();
    }
}
