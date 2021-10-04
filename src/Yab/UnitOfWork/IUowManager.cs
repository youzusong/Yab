namespace Yab.UnitOfWork
{
    /// <summary>
    /// 工作单元管理者接口
    /// </summary>
    public interface IUowManager
    {
        /// <summary>
        /// 当前工作单元
        /// </summary>
        IUow Current { get; set; }

        /// <summary>
        /// 开启工作单元
        /// </summary>
        /// <param name="options"></param>
        /// <param name="requiresNew"></param>
        /// <returns></returns>
        IUow Begin(UowOptions options, bool requiresNew = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reservationName"></param>
        /// <param name="requiresNew"></param>
        /// <returns></returns>
        IUow Reserve(string reservationName, bool requiresNew = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reservationName"></param>
        /// <param name="options"></param>
        void BeginReserved(string reservationName, UowOptions options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reservationName"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        bool TryBeginReserved(string reservationName, UowOptions options);
    }
}
