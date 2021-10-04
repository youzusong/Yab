using System.Threading;
using Yab.DependencyInjection;

namespace Yab.UnitOfWork
{
    [ExposeServices(typeof(IUowAmbient))]
    public class UowAmbient : IUowAmbient, ISingletonDependency
    {
        private readonly AsyncLocal<IUow> _currentUow;

        public IUow Uow => _currentUow.Value;

        public UowAmbient()
        {
            _currentUow = new AsyncLocal<IUow>();
        }

        public void SetUow(IUow uow)
        {
            _currentUow.Value = uow;
        }
    }
}
