using System;

namespace Yab.Serialization.Json
{
    /// <summary>
    /// JSON序列化器接口
    /// </summary>
    public interface IJsonSerializer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="useCamelCase"></param>
        /// <param name="withIndent"></param>
        /// <returns></returns>
        string Serialize(object obj, bool useCamelCase = true, bool withIndent = false);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <param name="useCamelCase"></param>
        /// <returns></returns>
        T Deserialize<T>(string jsonString, bool useCamelCase = true);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="jsonString"></param>
        /// <param name="useCamelCase"></param>
        /// <returns></returns>
        object Deserialize(Type type, string jsonString, bool useCamelCase = true);
    }
}
