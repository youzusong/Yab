using Microsoft.AspNetCore.Http;
using System.Threading;
using Yab.DependencyInjection;
using Yab.Threading;

namespace Yab.AspNetCore.Threading
{
    public class HttpContextCancellationTokenProvider : ICancellationTokenProvider, ITransientDependency
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CancellationToken Token => _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;

        public HttpContextCancellationTokenProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
