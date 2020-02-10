﻿using System;
using System.Threading.Tasks;
using ConsidKompetens_Services.Interfaces;
using ConsidKompetens_Web.Communication;
using ConsidKompetens_Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RegisterService = ConsidKompetens_Web.Services.RegisterService;

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
    public async Task<IActionResult> Post([FromBody] RegisterModelReq registerModel)
    {
      if (ModelState.IsValid)
      {
        //1. Check if user already exists
        if (!await _registerService.CheckIfUserExistsAsync(registerModel.UserName))
        {
          //2. If not create new identity user
          await _registerService.RegisterNewUserAsync(registerModel);
          return Ok("User and new profile created successfully");
        }

        return BadRequest("An account with the specified e-mail address already exists");
      }
      return BadRequest(_logger.ToString());

    }
  }
}
