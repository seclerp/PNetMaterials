using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SensorFusion.Web.App.Data.Models;
using SensorFusion.Web.App.Services.Abstractions;

namespace SensorFusion.Web.App.Controllers
{
  [ApiController]
  [Route("api/staticdata")]
  public class StaticDataController : Controller
  {
    private readonly IStaticDataProvider _staticDataProvider;

    public StaticDataController(IStaticDataProvider staticDataProvider)
    {
      _staticDataProvider = staticDataProvider;
    }

    [HttpGet("")]
    public StaticDataModel Index() => _staticDataProvider.GetStaticData();
  }
}