using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using SensorFusion.Shared.Data;
using SensorFusion.Shared.Data.Events;
using SensorFusion.Web.App.Services.Abstractions;
using StackExchange.Redis;

namespace SensorFusion.Web.App.Filters
{
  public class SubscriptionsSetupFilter : IStartupFilter
  {
    private readonly IConnectionMultiplexer _redisConnection;
    private readonly ISensorHistoryService _sensorHistoryService;

    public SubscriptionsSetupFilter(IConnectionMultiplexer redisConnection, ISensorHistoryService sensorHistoryService)
    {
      _redisConnection = redisConnection;
      _sensorHistoryService = sensorHistoryService;
    }

    public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
    {
      return builder =>
      {
        var subscriber = _redisConnection.GetSubscriber();

        subscriber.Subscribe(RedisConstants.SensorValuesChannel, (channel, value) =>
        {
          var dto = JsonConvert.DeserializeObject<NewSensorValueEvent>(value.ToString());
          _sensorHistoryService.AddValue(dto.SensorId, dto.Value, dto.TimeSent);
        });

        next(builder);
      };
    }
  }
}