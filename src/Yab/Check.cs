using System;

namespace Yab
{
    public static class Check
    {
        public static T NotNull<T>(T paramValue, string paramName)
        {
            if (paramValue == null)
                throw new ArgumentNullException(paramName);

            return paramValue;
        }

        public static bool IsNullOrWhiteSpace(this string str)
        {
            return String.IsNullOrWhiteSpace(str);
        }

        public static string NotNullOrWhiteSpace(
           string paramValue,
           string paramName,
           int maxLength = int.MaxValue,
           int minLength = 0)
        {
            if (paramValue.IsNullOrWhiteSpace())
            {
                throw new ArgumentException($"{paramName} can not be null, empty or white space!", paramName);
            }

            if (paramValue.Length > maxLength)
            {
                throw new ArgumentException($"{paramName} length must be equal to or lower than {maxLength}!", paramName);
            }

            if (minLength > 0 && paramValue.Length < minLength)
            {
                throw new ArgumentException($"{paramName} length must be equal to or bigger than {minLength}!", paramName);
            }

            return paramValue;
        }
    }
}
