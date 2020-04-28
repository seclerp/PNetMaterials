using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SensorFusion.Shared.Data.Entities;
using SensorFusion.Web.App.Data.Dtos;

namespace SensorFusion.Web.App.Controllers
{
  [Route("account")]
  public class AccountController : Controller
  {
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;

    public AccountController(
      UserManager<User> userManager,
      SignInManager<User> signInManager,
      IConfiguration configuration
    )
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _configuration = configuration;
    }

    [HttpPost("authorize")]
    public async Task<object> Authorize([FromBody] AuthorizeDto model)
    {
      var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

      if (result.Succeeded)
      {
        var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
        var token = GenerateJwtToken(model.Email, appUser);
        return new {token};
      }

      throw new Exception($"Failed to authorize user, reason: {result}");
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto model)
    {
      var user = new User
      {
        UserName = model.Email,
        Email = model.Email
      };
      var result = await _userManager.CreateAsync(user, model.Password);

      if (result.Succeeded)
      {
        await _signInManager.SignInAsync(user, false);
      }

      return Ok();
    }

    private string GenerateJwtToken(string email, IdentityUser user)
    {
      var claims = new List<Claim>
      {
        new Claim(JwtRegisteredClaimNames.Sub, email),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(ClaimTypes.NameIdentifier, user.Id)
      };

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Auth:Key"]));
      var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
      var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["Auth:ExpireDays"]));

      var token = new JwtSecurityToken(
        _configuration["Auth:Issuer"],
        _configuration["Auth:Issuer"],
        claims,
        expires: expires,
        signingCredentials: credentials
      );

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}