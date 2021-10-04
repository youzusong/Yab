using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yab.DependencyInjection;
using Yab.DynamicProxy;

namespace Yab.UnitOfWork
{
    public class UowInterceptor : InterceptorBase, ITransientDependency
    {
        public override async Task InterceptAsync(IInvocation invocation)
        {

            await invocation.ProceedAsync();

        }
    }
}
