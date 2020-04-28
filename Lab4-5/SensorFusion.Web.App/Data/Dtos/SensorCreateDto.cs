using System.ComponentModel.DataAnnotations;

namespace SensorFusion.Web.App.Data.Dtos
{
  public class SensorCreateDto
  {
    [Required]
    public string Name { get; set; }
  }
}