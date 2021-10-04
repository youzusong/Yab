using System.Threading.Tasks;

namespace Yab.DynamicProxy
{
    /// <summary>
    /// 拦截器接口
    /// </summary>
    public interface IInterceptor
    {
        /// <summary>
        /// 拦截
        /// </summary>
        /// <param name="invocation"></param>
        /// <returns></returns>
        Task InterceptAsync(IInvocation invocation);
    }
}
