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
    //private readonly IEmailSender _emailSender;
    private readonly IProfileDataService _profileDataService;

    public RegisterService(UserManager<IdentityUser> userManager, /*IEmailSender emailSender,*/ IProfileDataService profileDataService, IOptions<AppSettings> options)
    {
      _userManager = userManager;
      //_emailSender = emailSender;
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

    public async Task<IdentityUser> RegisterNewUserAsync(RegisterModelReq newModel)
    {
      try
      {
        var newUser = new IdentityUser { UserName = newModel.UserName, Email = newModel.UserName };
        //remove once email service is in place
        //newUser.EmailConfirmed = true;
        //await SendEmailConfirmationAsync(newUser);

        await _userManager.CreateAsync(newUser);

        await _userManager.AddPasswordAsync(newUser, newModel.PassWord);
        var owner = await _userManager.FindByNameAsync(newUser.UserName);
        await _profileDataService.CreateNewProfileAsync(owner.Id);

        return await _userManager.FindByNameAsync(newModel.UserName);
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
      var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlContent);
      await client.SendEmailAsync(msg);
    }
  }
}