using System;
using System.Runtime.Serialization;

namespace Yab
{
    public class YabException : Exception
    {
        public string ErrorCode { get; protected set; }

        public YabException()
        { }

        public YabException(string message)
            : base(message)
        { }

        public YabException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public YabException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        { }

    }
}
