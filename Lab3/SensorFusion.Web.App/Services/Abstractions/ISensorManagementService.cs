using System.Collections.Generic;
using System.Threading.Tasks;
using SensorFusion.Shared.Data.Entities;

namespace SensorFusion.Web.App.Services.Abstractions
{
  public interface ISensorManagementService
  {
    Task<int> Create(User user, string name);
    Task<Sensor> Get(int id);
    IEnumerable<Sensor> GetAllByUser(User user);
    Task Rename(int id, string name);
    Task Delete(int id);
  }
}