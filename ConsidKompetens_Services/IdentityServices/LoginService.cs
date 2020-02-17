using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ConsidKompetens_Services.Helpers;
using ConsidKompetens_Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ConsidKompetens_Services.IdentityServices
{
  public class LoginService : ILoginService
  {
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly AppSettings _appSettings;
    private readonly ILogger<LoginService> _logger;

    public LoginService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IOptions<AppSettings> appSettings, ILogger<LoginService> logger)
    {
      _signInManager = signInManager;
      _userManager = userManager;
      _logger = logger;
      _appSettings = appSettings.Value;

    }
    public string GenerateToken(IdentityUser user)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
        {
          new Claim(ClaimTypes.Name, user.Id),
        }),
        Expires = DateTime.UtcNow.AddHours(12),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
      var jwtToken = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
      var token = tokenHandler.WriteToken(jwtToken);
      return token;
    }

    public async Task<IdentityUser> ValidateUserAsync(string userName, string passWord)
    {
      try
      {
        var user = await _userManager.FindByNameAsync(userName);
        SignInResult signInResult = await _signInManager.PasswordSignInAsync(user.UserName, passWord, false, false);
        if (signInResult.Succeeded)
        {
          return user;
        }
        throw new Exception(_logger.ToString());
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<bool> LogOutUserAsync()
    {
      try
      {
        await _signInManager.SignOutAsync();
        return true;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
  }
}