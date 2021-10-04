using System.Threading.Tasks;

namespace Yab.DynamicProxy
{
    /// <summary>
    /// 拦截器基类
    /// </summary>
    public abstract class InterceptorBase : IInterceptor
    {
        public abstract Task InterceptAsync(IInvocation invocation);
    }
}
