using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Yab.DynamicProxy
{
    /// <summary>
    /// 拦截信息接口
    /// </summary>
    public interface IInvocation
    {
        /// <summary>
        /// 参数
        /// </summary>
        object[] Arguments { get; }

        /// <summary>
        /// 泛型参数
        /// </summary>
        Type[] GenericArguments { get; }

        /// <summary>
        /// 参数字典
        /// </summary>
        IReadOnlyDictionary<string, object> ArgumentsDictionary { get; }

        /// <summary>
        /// 目标
        /// </summary>
        object Target { get; }

        /// <summary>
        /// 方法
        /// </summary>
        MethodInfo Method { get; }

        /// <summary>
        /// 返回值
        /// </summary>
        object ReturnValue { get; set; }

        /// <summary>
        /// 执行
        /// </summary>
        /// <returns></returns>
        Task ProceedAsync();
    }
}
