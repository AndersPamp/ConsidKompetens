using System;
using System.Security.Policy;
using System.Threading.Tasks;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Services.Interfaces;
using ConsidKompetens_Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;

namespace ConsidKompetens_Services.IdentityServices
{
  public class RegisterService : IRegisterService
  {
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ILogger<RegisterModelReq> _logger;
    private readonly IEmailSender _emailSender;
    private readonly IProfileDataService _profileDataService;

    public RegisterService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, ILogger<RegisterModelReq> logger, IEmailSender emailSender, IProfileDataService profileDataService)
    {
      _signInManager = signInManager;
      _userManager = userManager;
      _logger = logger;
      _emailSender = emailSender;
      _profileDataService = profileDataService;
    }

    public async Task<bool> CheckIfUserExistsAsync(string userName)
    {
      return await _userManager.FindByNameAsync(userName) != null;
    }

    public async Task<bool> RegisterNewUserAsync(RegisterModelReq newModel)
    {
      try
      {
        var newUser = new IdentityUser(newModel.UserName) { Email = newModel.UserName };
        //remove once email service is in place
        newUser.EmailConfirmed = true;
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

    public async Task EmailConfirmationAsync(IdentityUser user)
    {
      var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
      
    }
  }
}