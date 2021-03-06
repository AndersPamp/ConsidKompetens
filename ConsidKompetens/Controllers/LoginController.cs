﻿using System;
using System.Threading.Tasks;
using ConsidKompetens_Core.Response_Request;
using ConsidKompetens_Services.Interfaces;
using ConsidKompetens_Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ConsidKompetens_Web.Controllers
{
  [AllowAnonymous]
  [Route("api/[controller]")]
  [ApiController]
  public class LoginController : ControllerBase
  {
    private readonly ILoginService _loginService;
    //public static int count { get; set; }

    public LoginController(ILoginService loginService)
    {
      _loginService = loginService;
    }

    // POST: api/Login
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginReq loginModel)
    {
      if (ModelState.IsValid)
      {
        //1. Validate user in db
        var user = await _loginService.ValidateUserAsync(loginModel.UserName, loginModel.PassWord);
        if (user != null)
        {
          //2. Generate token if user exists
          var token = _loginService.GenerateToken(user);

          return Ok(new Response { Success = true, BearerToken = token, Data = new ResponseData { Email = user.Email } });
        }
        //3. If user unauth. return UnAuthorized
        return Unauthorized(new Response { Success = false, ErrorMessage = "Email-address and/or password - incorrect" });
      }
      return Unauthorized(new Response { Success = false, ErrorMessage = "Both email-address and password must be submitted" });
    }

    [HttpPost]
    [Route("ResetPassword")]
    public async Task<IActionResult> ResetPassword([FromBody]ResetPasswordReq input)
    {

      if (!ModelState.IsValid)
      {
        return BadRequest(new Response { Success = false, ErrorMessage = "The details provided are not complete." });
      }
      if (input.Password != input.ConfirmPassword)
      {
        return BadRequest("Password and Confirmed password must be identical");
      }
      if (!PasswordStrength.CheckPasswordComplexity(input.Password))
      {
        return BadRequest("Password not strong enough.");
      }
      input.Token = System.Net.WebUtility.UrlDecode(input.Token);
      if (await _loginService.ResetPasswordAsync(input))
      {
        return Ok(new Response { Success = true });
      }

      return StatusCode(500, new Response { Success = false, ErrorMessage = "Something went wrong while trying to reset your password." });

    }

    [HttpGet]
    [Route("SendResetEmail")]
    public async Task<IActionResult> SendResetEmail([FromHeader]string email)
    {
      try
      {
        var user = await _loginService.FindUserByEmailAsync(email);
        var token = await _loginService.GenerateResetTokenAsync(user);
        var link = Url.Action(action: "ResetPassword", controller: "Login",
          new { userEmail = user.Email, token = token }, Request.Scheme);

        if (await _loginService.SendResetPasswordEmailAsync(email, link))
        {
          return Ok(new Response { Success = true });
        }

        return StatusCode(503, new Response { Success = false, ErrorMessage = "Something went wrong while trying to send the reset email to your address." });
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
