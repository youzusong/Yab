using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yab.DependencyInjection;
using AliyunClient = AlibabaCloud.SDK.Dysmsapi20170525.Client;
using AliyunConfig = AlibabaCloud.OpenApiClient.Models.Config;
using AliyunSendSmsRequest = AlibabaCloud.SDK.Dysmsapi20170525.Models.SendSmsRequest;

namespace Yab.Message.Sms.Aliyun
{
    public class AliyunSmsSender : ISmsSender, ITransientDependency
    {
        protected YabAliyunSmsOptions Options { get; }

        public AliyunSmsSender(IOptionsSnapshot<YabAliyunSmsOptions> options)
        {
            Options = options.Value;
        }

        protected virtual AliyunClient CreateClient()
        {
            return new(new AliyunConfig
            {
                AccessKeyId = Options.AccessKeyId,
                AccessKeySecret = Options.AccessKeySecret,
                Endpoint = Options.EndPoint
            });
        }

        public async Task SendAsync(SmsMessage smsMessage)
        {
            var client = CreateClient();
            var request = new AliyunSendSmsRequest
            {
                PhoneNumbers = smsMessage.PhoneNo,
                SignName = smsMessage.Properties.GetOrDefault(YabAliyunSmsConsts.SignNameKey) as string,
                TemplateCode = smsMessage.Properties.GetOrDefault(YabAliyunSmsConsts.TemplateCodeKey) as string,
                TemplateParam = smsMessage.Text
            };

            var response = await client.SendSmsAsync(request);

            // TODO: logging...

        }

    }
}
