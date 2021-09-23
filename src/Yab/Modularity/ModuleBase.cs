namespace Yab.Modularity
{
    public abstract class ModuleBase : IModule
    {
        public virtual void PreConfigureServices(AppServiceConfigurationContext context)
        { }

        public virtual void ConfigureServices(AppServiceConfigurationContext context)
        { }

        public virtual void PostConfigureServices(AppServiceConfigurationContext context)
        { }

        public virtual void PreInitializeApplication(AppInitializationContext context)
        { }

        public virtual void InitializeApplication(AppInitializationContext context)
        { }

        public virtual void PostInitializeApplication(AppInitializationContext context)
        { }

        public virtual void ShutdownApplication(AppInitializationContext context)
        { }
    }
}
