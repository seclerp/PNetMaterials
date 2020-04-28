using System;

namespace SensorFusion.Shared.Data.Entities
{
  public class SensorValue
  {
    public int SensorId { get; set; }
    public string Value { get; set; }
    public DateTime TimeSent { get; set; }
  }
}