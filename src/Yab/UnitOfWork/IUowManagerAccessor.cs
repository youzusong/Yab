namespace Yab.UnitOfWork
{
    public interface IUowManagerAccessor
    {
        IUowManager UowManager { get; }
    }
}
