using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SensorFusion.Shared.Data.Entities;
using SensorFusion.Web.App.Data.Dtos;
using SensorFusion.Web.App.Data.Models;
using SensorFusion.Web.App.Services.Abstractions;

namespace SensorFusion.Web.App.Controllers
{
  [ApiController]
  [Route("api/sensors")]
  public class SensorsController : ControllerBase
  {
    private readonly ISensorManagementService _sensorManagementService;
    private readonly UserManager<User> _userManager;

    public SensorsController(ISensorManagementService sensorManagementService, UserManager<User> userManager)
    {
      _sensorManagementService = sensorManagementService;
      _userManager = userManager;
    }

    [Authorize]
    [HttpPost("create")]
    public async Task Create([FromBody] SensorCreateDto createDto)
    {
      var user = await _userManager.GetUserAsync(User);
      await _sensorManagementService.Create(user, createDto.Name);
    }

    [Authorize]
    [HttpPut("rename")]
    public async Task Rename([FromBody] SensorRenameDto renameDto)
    {
      await _sensorManagementService.Rename(renameDto.Id, renameDto.Name);
    }

    [Authorize]
    [HttpGet("")]
    public async Task<List<SensorModel>> GetByUser()
    {
      var user = await _userManager.GetUserAsync(User);

      return _sensorManagementService
        .GetAllByUser(user)
        .Select(Map)
        .ToList();
    }

    private static SensorModel Map(Sensor sensor) =>
      new SensorModel
      {
        Id = sensor.Id,
        Key = sensor.Key,
        Name = sensor.Name
      };
  }
}