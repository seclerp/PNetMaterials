using System;
using System.Threading.Tasks;

namespace SensorFusion.Web.App.Services.Abstractions
{
  public interface ISensorHistoryService
  {
    Task AddValue(int sensorId, string value, DateTime timeSent);
  }
}