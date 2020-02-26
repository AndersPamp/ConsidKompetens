using System;
using System.Collections.Generic;
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
  [Route("api/[controller]")]
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
      var userId = this.User.Identity.Name;
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
    [Route("editprofile")]
    
    public async Task<ActionResult<ResponseModel>> EditProfile([FromBody] ProfileModel value)
    {
      if (ModelState.IsValid)
      {
        try
        {
          var profile = await _profileDataService.GetProfileByOwnerIdAsync(this.User.Identity.Name);
          var result = await _profileDataService.EditProfileByIdAsync(profile.Id, value);

          return Ok(new ResponseModel { Success = true, Data = new ResponseData { ProfileModels = new List<ProfileModel> { result } } });
        }
        catch (Exception e)
        {
          return BadRequest(new ResponseModel { Success = false, ErrorMessage = e.Message});
        }
      }
      return BadRequest(new ResponseModel { Success = false, ErrorMessage = _logger.ToString()});
    }

    [HttpPut]
    [Route("uploadimage")]
    public async Task<ActionResult<IFormFile>> UploadImage([FromForm]IFormFile file)
    {
      try
      {
        var profile = await _profileDataService.GetProfileByOwnerIdAsync(this.User.Identity.Name);
        if (await _profileDataService.ImageUploadAsync(profile.OwnerID, file))
        {
          return Ok(new ResponseModel { Success = true, Data = new ResponseData { ProfileModels = new List<ProfileModel>{await _profileDataService.GetProfileByOwnerIdAsync(profile.OwnerID)}} });
        }

        return BadRequest(new ResponseModel {Success = false, ErrorMessage = _logger.ToString()});
      }
      catch (Exception e)
      {
        return BadRequest(new ResponseModel {Success = false, ErrorMessage = e.Message});
      }
    }

    //DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<ResponseModel>> Delete(int id)
    {
      if (await _profileDataService.DeleteProfileAsync(id))
      {
        return Ok(new ResponseModel {Success = true});
      }

      return BadRequest(_logger.ToString());
    }
  }
}
