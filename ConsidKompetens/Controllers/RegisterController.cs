using System;
using System.IO;
using System.Threading.Tasks;
using ConsidKompetens_Core.CommunicationModels;
using ConsidKompetens_Services.Helpers;
using ConsidKompetens_Services.Interfaces;
using ConsidKompetens_Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ConsidKompetens_Web.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [AllowAnonymous]
  public class RegisterController : ControllerBase
  {
    private readonly IRegisterService _registerService;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ILogger<RegisterController> _logger;
    private readonly IOptions<AppSettings> _options;

    public RegisterController(IRegisterService registerService, UserManager<IdentityUser> userManager,
      ILogger<RegisterController> logger, IOptions<AppSettings> options)
    {
      _registerService = registerService;
      _userManager = userManager;
      _logger = logger;
      _options = options;
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
          if (PasswordStrength.CheckPasswordComplexity(registerModel.PassWord) &&
              registerModel.UserName.EndsWith("@consid.se"))
          {
            //3. Create new identity user
            var user = await _registerService.RegisterNewUserAsync(registerModel);
            if (user != null)
            {

              var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
              var link = Url.Action(action: "ConfirmEmail", controller: "Register",
                new { userId = user.Id, token = token }, Request.Scheme);

              await _registerService.SendEmailConfirmationAsync(user, link);

              //Write confirmationlink to file in MyPictures
              //var filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
              //System.IO.File.WriteAllText(Path.Combine(filePath, $"ConfirmEmail---{user.Id}.txt"), link);

              return Created("", new ResponseModel { Success = true });
            }
          }

          return BadRequest(new ResponseModel
          { Success = false, ErrorMessage = "Password not strong enough or invalid email-address" });
        }

        return BadRequest(new ResponseModel
        { Success = false, ErrorMessage = "A user with the submitted email-address already exists" });
      }

      return BadRequest(new ResponseModel
      { Success = false, ErrorMessage = "Both email and password must be submitted" });
    }

    [HttpGet]
    [Route("ConfirmEmail")]
    public async Task<IActionResult> ConfirmEmail(string userId, string token)
    {
      if (userId == null || token == null)
      {
        return BadRequest("Unable to confirm without submitted email-address and/or password");
      }

      var user = await _userManager.FindByIdAsync(userId);
      if (user == null)
      {
        return BadRequest($"Unable to load user with ID '{userId}'.");
      }

      var result = await _userManager.ConfirmEmailAsync(user, token);
      if (result.Succeeded)
      {
        return Ok(new ResponseModel { Success = true });
      }

      return BadRequest();
    }
  }
}
