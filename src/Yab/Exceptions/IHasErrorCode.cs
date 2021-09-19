namespace Yab.Exceptions
{
    public interface IHasErrorCode
    {
        /// <summary>
        /// 错误代号
        /// </summary>
        string ErrorCode { get; }
    }
}
