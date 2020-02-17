using System.Threading.Tasks;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Services.Interfaces;
using ConsidKompetens_Web.Helpers;
using ConsidKompetens_Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConsidKompetens_Web.Controllers
{
  [Route("api/[controller]/[action]")]
  [ApiController]
  [AllowAnonymous]
  public class RegisterController : ControllerBase
  {
    private readonly ILogger<RegisterModelReq> _logger;
    private readonly IRegisterService _registerService;
    public RegisterController(ILogger<RegisterModelReq> logger, IRegisterService registerService)
    {
      _logger = logger;
      _registerService = registerService;
    }

    // POST: api/Register
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] RegisterModelReq registerModel)
    {
      if (ModelState.IsValid)
      {
        //1. Check if user already exists
        if (!await _registerService.CheckIfUserExistsAsync(registerModel.UserName))
        {
          //2. Check if password is strong enough
          if (PasswordStrength.CheckPasswordComplexity(registerModel.PassWord))
          {
            //3. Create new identity user
            await _registerService.RegisterNewUserAsync(registerModel);
            return Ok(new SpaPageModel{PageTitle = "Register", Ok = true,Message = "User and new profile created successfully" });
          }
          return BadRequest(new SpaPageModel{ PageTitle = "Register", Ok = false, Message = "Password doesn't meet criteria"});
        }
        return BadRequest(new SpaPageModel{PageTitle = "Register", Ok = false, Message = "An account with the specified e-mail address already exists" });
      }
      return BadRequest(new SpaPageModel{PageTitle = "Register", Ok = false, Message = _logger.ToString()});
    }
  }
}
