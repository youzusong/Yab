using System;

namespace Yab.UnitOfWork
{
    public class UowEventArgs : EventArgs
    {
        public IUow Uow { get; }

        public UowEventArgs(IUow uow)
        {
            Uow = uow;
        }
    }
}
