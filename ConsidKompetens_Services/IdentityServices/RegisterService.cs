using System;
using System.Threading.Tasks;
using ConsidKompetens_Core.CommunicationModels;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Services.Helpers;
using ConsidKompetens_Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ConsidKompetens_Services.IdentityServices
{
  public class RegisterService : IRegisterService
  {
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ILogger<RegisterModelReq> _logger;
    private readonly IOptions<AppSettings> _options;
    //private readonly IEmailSender _emailSender;
    private readonly IProfileDataService _profileDataService;

    public RegisterService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, ILogger<RegisterModelReq> logger, /*IEmailSender emailSender,*/ IProfileDataService profileDataService, IOptions<AppSettings> options)
    {
      _signInManager = signInManager;
      _userManager = userManager;
      _logger = logger;
      //_emailSender = emailSender;
      _profileDataService = profileDataService;
      _options = options;
    }

    public async Task<bool> CheckIfUserExistsAsync(string userName)
    {
      return await _userManager.FindByNameAsync(userName) != null;
    }

    public async Task<bool> RegisterNewUserAsync(RegisterModelReq newModel)
    {
      try
      {
        var newUser = new IdentityUser { UserName = newModel.UserName, Email = newModel.UserName };
        //remove once email service is in place
        newUser.EmailConfirmed = true;
        //await SendEmailConfirmationAsync(newUser);
        
        await _userManager.CreateAsync(newUser);

        await _userManager.AddPasswordAsync(newUser, newModel.PassWord);
        var owner = await _userManager.FindByNameAsync(newUser.UserName);
        await _profileDataService.CreateNewProfileAsync(owner.Id);

        return true;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    private async Task SendEmailConfirmationAsync(IdentityUser user)
    {
      var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
      var apiKey = _options.Value.EmailAPIKey;
      var client = new SendGridClient(apiKey);
      var from = new EmailAddress(_options.Value.EmailFromAddress);
      var subject = _options.Value.EmailConfirmSubject;
      var to = new EmailAddress(user.Email);
      var htmlContent = $"<link>{token}</link>";
      var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlContent);
      var response = await client.SendEmailAsync(msg);
    }
  }
}