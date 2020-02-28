using System.Threading.Tasks;
using ConsidKompetens_Core.CommunicationModels;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConsidKompetens_Web.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class LogoutController : ControllerBase
  {
    private readonly ILoginService _loginService;
    private readonly ILogger<LogoutController> _logger;

    public LogoutController(ILoginService loginService, ILogger<LogoutController> logger)
    {
      _loginService = loginService;
      _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult<bool>> Logout(bool logOut)
    {
      if (logOut)
      {
        await _loginService.LogOutUserAsync();
        return Ok(new ResponseModel { Success = true });
      }
      return BadRequest(new ResponseModel { Success = false, ErrorMessage = _logger.ToString() });
    }
  }
}