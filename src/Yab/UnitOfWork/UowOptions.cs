using System.Data;

namespace Yab.UnitOfWork
{
    public class UowOptions
    {
        public bool IsTransactional { get; set; }

        public IsolationLevel? IsolationLevel { get; set; }

        public int? Timeout { get; set; }

        public UowOptions()
        { }

        public UowOptions Clone()
        {
            return new UowOptions
            {
                IsTransactional = IsTransactional,
                IsolationLevel = IsolationLevel,
                Timeout = Timeout
            };
        }
    }
}
