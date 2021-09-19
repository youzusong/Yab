using Yab.DependencyInjection;
using Yab.Threading;

namespace Yab.Background
{
    /// <summary>
    /// 后台工作者接口
    /// </summary>
    public interface IBackgroundWorker : IRunnable, ISingletonDependency
    {

    }
}
