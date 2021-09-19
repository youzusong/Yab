using Newtonsoft.Json;
using System.Collections.Generic;

namespace Yab.Serialization.Json.Newtonsoft
{
    /// <summary>
    /// NewtonsoftJson配置项
    /// </summary>
    public class YabNewtonsoftJsonOptions
    {
        public IList<JsonConverter> Converters { get; }

        public YabNewtonsoftJsonOptions()
        {
            Converters = new List<JsonConverter>();
        }
    }
}
