using System;

namespace Yab.UnitOfWork
{
    public class UowFailedEventArgs : UowEventArgs
    {
        public Exception Exception { get; }

        public bool IsRollbacked { get; }

        public UowFailedEventArgs(IUow uow, Exception exception, bool isRollbacked)
            : base(uow)
        {
            Exception = exception;
            IsRollbacked = isRollbacked;
        }
    }
}
