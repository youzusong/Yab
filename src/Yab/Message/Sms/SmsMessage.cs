using System.Collections.Generic;

namespace Yab.Message.Sms
{
    public class SmsMessage
    {
        public string PhoneNo { get; set; }

        public string Text { get; set; }

        public IDictionary<string, object> Properties { get; }

        public SmsMessage(string phoneNo, string text)
        {
            PhoneNo = Check.NotNullOrWhiteSpace(phoneNo, nameof(phoneNo));
            Text = Check.NotNullOrWhiteSpace(text, nameof(text));
            Properties = new Dictionary<string, object>();
        }
    }
}
