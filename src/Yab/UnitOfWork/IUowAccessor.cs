namespace Yab.UnitOfWork
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUowAccessor
    {
        /// <summary>
        /// 
        /// </summary>
        IUow Uow { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uow"></param>
        void SetUow(IUow uow);
    }
}
