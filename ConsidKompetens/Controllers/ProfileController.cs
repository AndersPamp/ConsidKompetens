using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ConsidKompetens_Core.CommunicationModels;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Services.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConsidKompetens_Web.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class ProfileController : ControllerBase
  {
    private readonly IProfileDataService _profileDataService;
    private readonly IOfficeDataService _officeDataService;
    private readonly IOptions<AppSettings> _options;

    public ProfileController(IProfileDataService profileDataService, IOfficeDataService officeDataService, IOptions<AppSettings> options)
    {
      _profileDataService = profileDataService;
      _officeDataService = officeDataService;
      _options = options;
    }

    // GET: api/Profile
    [HttpGet]
    public async Task<ActionResult<ResponseModel>> Get()
    {
      var userId = this.User.Identity.Name;
      try
      {
        var profiles = await _profileDataService.GetAllProfilesAsync();
        var images = new List<string>();
        foreach (var profile in profiles)
        {
          images.Add(Path.Combine(Directory.GetCurrentDirectory(), profile.ProfileImage.Url));
        }
        return Ok(new ResponseModel()
        {
          Success = true,
          Data = new ResponseData
          {
            ProfileModels = profiles,
            Images = images
          }
        });
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
        var profile = await _profileDataService.GetProfileByIdAsync(id);
        return Ok(new ResponseModel
        {
          Success = true,
          Data = new ResponseData
          {
            ProfileModels = new List<ProfileModel> { profile },
            Images = new List<string> { Path.Combine(Directory.GetCurrentDirectory(), profile.ProfileImage.Url) }
          }
        });
      }
      catch (Exception e)
      {
        return BadRequest(new ResponseModel { Success = false, ErrorMessage = e.Message });
      }
    }

    [HttpGet]
    [Route("ownerid")]
    public async Task<ActionResult<ProfileModel>> GetProfileByOwnerId()
    {
      try
      {
        return await _profileDataService.GetProfileByOwnerIdAsync(this.User.Identity.Name);
      }
      catch (Exception e)
      {
        return BadRequest(new ResponseModel { Success = false, ErrorMessage = e });
      }
    }

    [HttpPut("{id}")]
    [Route("editprofile")]
    public async Task<ActionResult<ResponseModel>> EditProfile(ProfileModel input)
    {
      if (ModelState.IsValid)
      {
        try
        {
          var profile = await _profileDataService.GetProfileByOwnerIdAsync(this.User.Identity.Name);
          var result = await _profileDataService.EditProfileByIdAsync(profile.Id, input);

          return Ok(new ResponseModel
          {
            Success = true,
            Data = new ResponseData
            {
              ProfileModels = new List<ProfileModel> { result },
              OfficeModels = new List<OfficeModel> { await _officeDataService.GetOfficeByIdAsync(profile.OfficeId) }
            }
          });
        }
        catch (Exception e)
        {
          return BadRequest(new ResponseModel { Success = false, ErrorMessage = e.Message });
        }
      }
      return BadRequest(new ResponseModel { Success = false, ErrorMessage = ModelState.Values.ToString() });
    }

    [HttpPut]
    [Route("UploadImage")]
    public async Task<ActionResult<IFormFile>> UploadImage([FromForm]IFormFile file)
    {
      try
      {
        var profile = await _profileDataService.GetProfileByOwnerIdAsync(this.User.Identity.Name);
        if (await _profileDataService.ImageUploadAsync(profile.OwnerID, file))
        {
          return Ok(new ResponseModel
          {
            Success = true,
            Data = new ResponseData
            {
              ProfileModels = new List<ProfileModel> { await _profileDataService.GetProfileByOwnerIdAsync(profile.OwnerID) },
              Images = new List<string> { Path.Combine(Directory.GetCurrentDirectory(), profile.ProfileImage.Url) }
            }
          });
        }
        return BadRequest(new ResponseModel { Success = false, ErrorMessage = "Something went wrong while trying to upload your picture, please try again."});
      }
      catch (Exception e)
      {
        return BadRequest(new ResponseModel { Success = false, ErrorMessage = e.Message });
      }
    }

    //DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<ResponseModel>> Delete(int id)
    {

      if (await _profileDataService.DeleteProfileAsync(id))
      {
        return Ok(new ResponseModel { Success = true });
      }
      return BadRequest(new ResponseModel { Success = false, ErrorMessage = _profileDataService.DeleteProfileAsync(id).ToString() });
    }
  }
}
