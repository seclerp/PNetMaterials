namespace SensorFusion.Web.App.Data.Models
{
  public class MenuItem
  {
    public string Title { get; }
    public string Route { get; }
    public string Icon { get; }

    public MenuItem(string title, string route, string icon)
    {
      Title = title;
      Route = route;
      Icon = icon;
    }
  }
}