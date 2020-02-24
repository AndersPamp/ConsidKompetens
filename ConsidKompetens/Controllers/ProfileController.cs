using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConsidKompetens_Web.Controllers
{
  [Authorize]
  [Route("api/[controller]/[action]")]
  [ApiController]
  public class ProfileController : ControllerBase
  {
    private readonly IProfileDataService _profileDataService;
    private readonly ILogger<ProfileController> _logger;

    public ProfileController(IProfileDataService profileDataService, ILogger<ProfileController> logger)
    {
      _profileDataService = profileDataService;
      _logger = logger;
    }

    // GET: api/Profile
    [HttpGet]
    public async Task<ActionResult<ResponseModel>> Get()
    {
      try
      {
        var profiles = await _profileDataService.GetAllProfilesAsync();
        return Ok(new ResponseModel() { Success = true, Data = new ResponseData { ProfileModels = profiles } });
      }
      catch (Exception e)
      {
        return BadRequest(new ResponseModel { Success = false, ErrorMessage = e.Message });
      }
    }

    // GET: api/Profile/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ResponseModel>> Get(int id)
    {
      try
      {
        var user = await _profileDataService.GetProfileByIdAsync(id);
        return Ok(new ResponseModel { Success = true, Data = new ResponseData { ProfileModels = new List<ProfileModel> { user } } });
      }
      catch (Exception e)
      {
        return BadRequest(new ResponseModel { Success = false, ErrorMessage = e.Message });
      }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ResponseModel>> EditProfile([FromBody] ProfileModel value)
    {
      if (ModelState.IsValid)
      {
        try
        {
          var userId = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;

          var profile = await _profileDataService.GetProfileByOwnerIdAsync(userId);
          var result = await _profileDataService.EditProfileByIdAsync(profile.Id, value);

          return Ok(new ResponseModel { Success = true, Data = new ResponseData { ProfileModels = new List<ProfileModel> { result } } });
        }
        catch (Exception e)
        {
          return BadRequest(new ResponseModel { Success = false, ErrorMessage = e.Message });
        }
      }
      return BadRequest(new ResponseModel { Success = false, ErrorMessage = _logger.ToString() });
    }

    [HttpPut(template: "{id}")]
    public async Task<ActionResult<IFormFile>> EditImage(IFormFile file)
    {
      if (ModelState.IsValid)
      {
        await _profileDataService.ImageUploadAsync(file);
      }

      return BadRequest(_logger.ToString());
    }


    //DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public Task<ActionResult<ResponseModel>> Delete(int id)
    {
      return null;
    }
  }
}
