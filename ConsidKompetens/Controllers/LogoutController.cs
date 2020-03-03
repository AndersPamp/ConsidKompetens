using System;
using System.Threading.Tasks;
using ConsidKompetens_Core.CommunicationModels;
using ConsidKompetens_Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ConsidKompetens_Web.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class LogoutController : ControllerBase
  {
    private readonly ILoginService _loginService;
    private readonly SignInManager<IdentityUser> _signInManager;

    public LogoutController(ILoginService loginService, SignInManager<IdentityUser> signInManager)
    {
      _loginService = loginService;
      _signInManager = signInManager;
    }


    //Obsolete NOT WORKING 
    [HttpGet]
    public async Task<IActionResult> Logout()
    {
      foreach (var userClaim in this.User.Claims)
      {
        Console.Out.WriteLine(userClaim.Properties.Values);
        
      }
      await _signInManager.SignOutAsync();
      if (await _loginService.LogOutUserAsync())
      {
        return Ok(new ResponseModel { Success = true });
      } 
        
      return BadRequest(new ResponseModel { Success = false, ErrorMessage = "Something went wrong while trying to log out, please try again."});
    }
  }
}