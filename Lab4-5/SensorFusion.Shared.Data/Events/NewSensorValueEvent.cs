using System;

namespace SensorFusion.Shared.Data.Events
{
  public class NewSensorValueEvent
  {
    public int SensorId { get; set; }
    public string Value { get; set; }
    public DateTime TimeSent { get; set; }
  }
}