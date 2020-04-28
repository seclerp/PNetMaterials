using System.ComponentModel.DataAnnotations;

namespace SensorFusion.Web.App.Data.Dtos
{
  public class AuthorizeDto
  {
    [Required] public string Email { get; set; }

    [Required] public string Password { get; set; }
  }
}