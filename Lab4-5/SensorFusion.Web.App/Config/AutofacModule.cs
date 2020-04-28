using Autofac;
using SensorFusion.Web.App.Filters;
using SensorFusion.Web.App.Services;

namespace SensorFusion.Web.App.Config
{
  public class AutofacModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      base.Load(builder);

      builder
        .RegisterType<SubscriptionsSetupFilter>()
        .AsImplementedInterfaces();

      builder
        .RegisterType<StaticDataProvider>()
        .AsImplementedInterfaces()
        .SingleInstance();

      builder
        .RegisterType<SensorManagementService>()
        .AsImplementedInterfaces();

      builder
        .RegisterType<SensorHistoryService>()
        .AsImplementedInterfaces();
    }
  }
}