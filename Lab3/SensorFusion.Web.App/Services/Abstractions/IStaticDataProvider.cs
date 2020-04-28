using SensorFusion.Web.App.Data.Models;

namespace SensorFusion.Web.App.Services.Abstractions
{
  public interface IStaticDataProvider
  {
    StaticDataModel GetStaticData();
  }

  // Register as Single instance
}