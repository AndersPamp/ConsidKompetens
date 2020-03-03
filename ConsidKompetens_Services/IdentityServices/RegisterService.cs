using System;
using System.Threading.Tasks;
using ConsidKompetens_Core.CommunicationModels;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Services.Helpers;
using ConsidKompetens_Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ConsidKompetens_Services.IdentityServices
{
  public class RegisterService : IRegisterService
  {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IOptions<AppSettings> _options;
    private readonly IProfileDataService _profileDataService;

    public RegisterService(UserManager<IdentityUser> userManager, IProfileDataService profileDataService, IOptions<AppSettings> options)
    {
      _userManager = userManager;
      _profileDataService = profileDataService;
      _options = options;
    }

    public async Task<bool> CheckIfUserExistsAsync(string userName)
    {
      try
      {
        return await _userManager.FindByNameAsync(userName) != null;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<IdentityUser> CheckIfUserIdExistsAsync(string userId)
    {
      try
      {
        return await _userManager.FindByIdAsync(userId);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<IdentityUser> RegisterNewUserAsync(RegisterModelReq newModel)
    {
      try
      {
        var newUser = new IdentityUser { UserName = newModel.UserName, Email = newModel.UserName };

        //Remove and activate email confirmation in RegisterController once in production
        newUser.EmailConfirmed = true;
        
        await _userManager.CreateAsync(newUser);
        await _userManager.AddPasswordAsync(newUser, newModel.PassWord);
        
        await _profileDataService.CreateNewProfileAsync((await _userManager.FindByNameAsync(newUser.UserName)).Id);

        return await _userManager.FindByNameAsync(newModel.UserName);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<string> GenerateEmailTokenAsync(IdentityUser user)
    {
      try
      {
        return await _userManager.GenerateEmailConfirmationTokenAsync(user);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<bool> ConfirmEmailAsync(string userId, string token)
    {
      try
      {
        await _userManager.ConfirmEmailAsync(await _userManager.FindByIdAsync(userId), token);
        return true;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
    
    public async Task SendEmailConfirmationAsync(IdentityUser user, string link)
    {
      var apiKey = _options.Value.EmailAPIKey;
      var client = new SendGridClient(apiKey);
      var from = new EmailAddress(_options.Value.EmailFromAddress);
      var subject = _options.Value.EmailConfirmSubject;
      var to = new EmailAddress(user.Email);
      var htmlContent = link;
      var msg = MailHelper.CreateSingleEmail(from, to, subject, "Test, test", htmlContent);
      await client.SendEmailAsync(msg);
    }
  }
}