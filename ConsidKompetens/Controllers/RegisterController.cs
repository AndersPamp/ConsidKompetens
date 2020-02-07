using System.Threading.Tasks;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Web.Areas.Identity.Pages.Account;
using ConsidKompetens_Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConsidKompetens_Web.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [AllowAnonymous]
  public class RegisterController : ControllerBase
  {
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ILogger<RegisterModelReq> _logger;
    private readonly IEmailSender _emailSender;
    private readonly IUserDataService _userDataService;

    public RegisterController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, ILogger<RegisterModelReq> logger, IEmailSender emailSender, IUserDataService userDataService)
    {
      _signInManager = signInManager;
      _userManager = userManager;
      _logger = logger;
      _emailSender = emailSender;
      _userDataService = userDataService;
    }

    // POST: api/Register
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] RegisterModelReq registerModel)
    {
      var newModel = new RegisterModelReq();
      return Created("", newModel);

    }
  }
}
