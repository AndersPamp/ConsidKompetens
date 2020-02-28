using System.Threading.Tasks;
using ConsidKompetens_Core.CommunicationModels;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Services.Interfaces;
using ConsidKompetens_Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConsidKompetens_Web.Controllers
{
  [Route("api/[controller]")]
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
    public async Task<IActionResult> Register([FromBody] RegisterModelReq registerModel)
    {
      if (ModelState.IsValid)
      {
        //1. Check if user already exists
        if (!await _registerService.CheckIfUserExistsAsync(registerModel.UserName))
        {
          //2. Check if password is strong enough
          if (PasswordStrength.CheckPasswordComplexity(registerModel.PassWord) && registerModel.UserName.EndsWith("@consid.se"))
          {
            //3. Create new identity user
            await _registerService.RegisterNewUserAsync(registerModel);
            return Created("", new ResponseModel { Success = true });
          }
          return BadRequest(new ResponseModel { Success= false, ErrorMessage= _logger.ToString() });
        }
        return BadRequest(new ResponseModel { Success= false, ErrorMessage= _logger.ToString() });
      }
      return BadRequest(new ResponseModel { Success= false, ErrorMessage= _logger.ToString() });
    }
  }
}
