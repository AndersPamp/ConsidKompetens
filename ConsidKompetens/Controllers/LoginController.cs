using System;
using System.Threading.Tasks;
using ConsidKompetens_Core.CommunicationModels;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConsidKompetens_Web.Controllers
{
  [AllowAnonymous]
  [Route("api/[controller]")]
  [ApiController]
  public class LoginController : ControllerBase
  {
    private readonly ILogger<LoginModelReq> _logger;
    private readonly ILoginService _loginService;
    //public static int count { get; set; }

    public LoginController(ILogger<LoginModelReq> logger, ILoginService loginService)
    {
      _logger = logger;
      _loginService = loginService;
    }

    //[HttpGet]
    //[OutputCache(Duration = 10)]
    //public IActionResult Testing()
    //{
    //  count++;
    //  return Ok(count);
    //}
    [HttpGet]
    public IActionResult Get()
    {
      return Ok(new ResponseModel { Success = true });
    }
    // POST: api/Login
    [HttpPost]
    //[Route("api/[controller]")]
    public async Task<IActionResult> Login([FromBody] LoginModelReq loginModel)
    {
      if (ModelState.IsValid)
      {
        //1. Validate user in db
        var user = await _loginService.ValidateUserAsync(loginModel.UserName, loginModel.PassWord);
        if (user != null)
        {
          //2. Generate token if user exists
          var token = _loginService.GenerateToken(user);
          return Ok(new ResponseModel { Success = true, BearerToken = token });
        }

        //3. If user unauth. return UnAuthorized
        return Unauthorized(new ResponseModel { Success = false, ErrorMessage = _logger.ToString() });

        //var returnUrl = "";
        //returnUrl = returnUrl ?? Url.Content("~/");
      }
      return Unauthorized(new ResponseModel { Success = false, ErrorMessage = _logger.ToString() });
    }
  }
}
