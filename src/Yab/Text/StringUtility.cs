using System;
using System.Text;
using System.Web;

namespace Yab.Text
{
    public static class StringUtility
    {
        public static string UrlDecode(string str)
        {
            return HttpUtility.UrlDecode(str);
        }

        public static string UrlEncode(string str, bool uppercase = false)
        {
            if (String.IsNullOrEmpty(str))
                return str;

            if (!uppercase)
                return HttpUtility.UrlEncode(str);

            var sb = new StringBuilder();
            foreach (char c in str)
            {
                var encC = HttpUtility.UrlEncode(c.ToString());
                sb.Append(encC.Length > 1 ? encC.ToUpper() : c);
            }
            return sb.ToString();
        }

    }
}
