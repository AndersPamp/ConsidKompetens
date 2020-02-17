using System.Threading.Tasks;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Services.Interfaces;
using ConsidKompetens_Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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

    public LoginController(ILogger<LoginModelReq> logger, ILoginService loginService)
    {
      _logger = logger;
      _loginService = loginService;
    }

    [HttpGet]
    public IActionResult Get()
    {
      return Ok(new SpaPageModel{PageTitle = "LoginPage", Ok = true});
    }
    // POST: api/Login
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] LoginModelReq loginModel)
    {
      if (ModelState.IsValid)
      {
        //1. Validate user in db
        var user = await _loginService.ValidateUser(loginModel.UserName, loginModel.PassWord);
        if (user!=null)
        {
          //2. Generate token if user exists
          var token = _loginService.GenerateToken(user);
          return Ok(new SpaPageModel{PageTitle = "Login", Ok = true, BearerToken = token});
        }
        
        //3. If user unauth. return UnAuthorized
        return Unauthorized(new SpaPageModel{PageTitle = "Login", Ok = false, Message = _logger.ToString()});

        //var returnUrl = "";
        //returnUrl = returnUrl ?? Url.Content("~/");
      }
      return Unauthorized(new SpaPageModel{PageTitle = "Login", Ok = false, Message = _logger.ToString()});
    }
  }
}
