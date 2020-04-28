using System.Collections.Generic;
using SensorFusion.Web.App.Data.Models;
using SensorFusion.Web.App.Services.Abstractions;

namespace SensorFusion.Web.App.Services
{
  class StaticDataProvider : IStaticDataProvider
  {
    private StaticDataModel _staticData => new StaticDataModel
    {
      Menu = new List<MenuItem>
      {
        new MenuItem("Dashboard", "",          "dashboard"),
        new MenuItem("Sensors",   "sensors",   "leak_add"),
        new MenuItem("Settings",  "settings",  "settings")
      },
      Locales = new List<Locale>
      {
        new Locale("English", "en_us")
      }
    };

    public StaticDataModel GetStaticData() => _staticData;
  }
}