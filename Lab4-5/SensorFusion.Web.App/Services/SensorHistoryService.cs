using System;
using System.Threading.Tasks;
using SensorFusion.Shared.Data;
using SensorFusion.Shared.Data.Entities;
using SensorFusion.Web.App.Services.Abstractions;

namespace SensorFusion.Web.App.Services
{
  class SensorHistoryService : ISensorHistoryService
  {
    private readonly AppDbContext _context;

    public SensorHistoryService(AppDbContext context) =>
      _context = context;

    public Task AddValue(int sensorId, string value, DateTime timeSent) =>
      _context.SensorValues.AddAsync(new SensorValue
      {
        SensorId = sensorId,
        Value = value,
        TimeSent = timeSent
      });
  }
}