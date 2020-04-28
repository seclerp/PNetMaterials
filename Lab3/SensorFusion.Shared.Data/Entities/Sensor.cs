namespace SensorFusion.Shared.Data.Entities
{
  public class Sensor
  {
    public int Id { get; set; }
    public User User { get; set; }
    public string Name { get; set; }
    public string Key { get; set; }
  }
}