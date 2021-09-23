namespace Yab.Modularity
{
    /// <summary>
    /// 模块接口
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="context">上下文</param>
        void ConfigureServices(AppServiceConfigurationContext context);
    }

}
