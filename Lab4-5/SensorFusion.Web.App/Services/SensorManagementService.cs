using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SensorFusion.Shared.Data;
using SensorFusion.Shared.Data.Entities;
using SensorFusion.Web.App.Data;
using SensorFusion.Web.App.Services.Abstractions;

namespace SensorFusion.Web.App.Services
{
  class SensorManagementService : ISensorManagementService
  {
    private readonly AppDbContext _context;

    public SensorManagementService(AppDbContext context)
    {
      _context = context;
    }

    public async Task<int> Create(User user, string name)
    {
      var sensor = new Sensor
      {
        User = user,
        Name = name,
        Key = GetNewKey()
      };

      _context.Sensors.Add(sensor);
      await _context.SaveChangesAsync();

      return sensor.Id;
    }

    public Task<Sensor> Get(int id) => _context.Sensors.FirstAsync(sensor => sensor.Id == id);

    public IEnumerable<Sensor> GetAllByUser(User user) => _context.Sensors.Where(sensor => sensor.User == user);

    public async Task Rename(int id, string name)
    {
      var sensor = await Get(id);
      sensor.Name = name;

      await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
      var sensor = await Get(id);
      _context.Sensors.Remove(sensor);

      await _context.SaveChangesAsync();
    }

    private static string GetNewKey() => Guid.NewGuid().ToString("N");
  }
}