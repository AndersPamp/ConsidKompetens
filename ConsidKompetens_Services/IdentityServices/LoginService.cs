using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ConsidKompetens_Core.CommunicationModels;
using ConsidKompetens_Services.Helpers;
using ConsidKompetens_Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ConsidKompetens_Services.IdentityServices
{
  public class LoginService : ILoginService
  {
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IOptions<AppSettings> _options;

    public LoginService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IOptions<AppSettings> options)
    {
      _signInManager = signInManager;
      _userManager = userManager;
      _options = options;

    }
    public string GenerateToken(IdentityUser user)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_options.Value.Secret);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
        {
          new Claim(ClaimTypes.Name, user.Id),
        }),
        Expires = DateTime.UtcNow.AddHours(24),
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
        var signInResult = await _signInManager.PasswordSignInAsync(user.UserName, passWord, false, false);
        if (signInResult.Succeeded)
        {
          return user;
        }
        throw new Exception(signInResult.ToString());
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

    public async Task<bool> SendResetPasswordEmailAsync(string email, string link)
    {
      try
      {
        var apiKey = _options.Value.EmailAPIKey;
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress(_options.Value.EmailFromAddress);
        var subject = _options.Value.EmailResetSubject;
        var to = new EmailAddress(email);
        var htmlContent = link;
        var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlContent);
        await client.SendEmailAsync(msg);

        return true;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<bool> ResetPasswordAsync(ResetPasswordModel input)
    {
      try
      {
        var user = await _userManager.FindByEmailAsync(input.Email);
        if (user.EmailConfirmed != true) throw new Exception("The email address submitted is not confirmed.");

        var result = await _userManager.ResetPasswordAsync(user, input.Token, input.Password);
        if (result.Succeeded) return true;
        throw new Exception(result.ToString());
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<string> GenerateResetTokenAsync(IdentityUser user)
    {
      try
      {
        return await _userManager.GeneratePasswordResetTokenAsync(user);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<IdentityUser> FindUserByEmailAsync(string email)
    {
      try
      {
        return await _userManager.FindByEmailAsync(email);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
  }
}