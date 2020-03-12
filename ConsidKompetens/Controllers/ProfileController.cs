using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ConsidKompetens_Core.DTO;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Core.Response_Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsidKompetens_Web.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class ProfileController : ControllerBase
  {
    private readonly IProfileDataService _profileDataService;
    private readonly IOfficeDataService _officeDataService;

    public ProfileController(IProfileDataService profileDataService, IOfficeDataService officeDataService)
    {
      _profileDataService = profileDataService;
      _officeDataService = officeDataService;
    }

    //public class ProfileResponse
    //{
    //  public IEnumerable<RelatedProfileResponse> Profiles { get; set; }
    //}


    //public class RelatedProfileResponse
    //{
    //  public static RelatedProfileResponse Map(ProfileModel profile)
    //  {
    //    return new RelatedProfileResponse();
    //  }
    //}


    // GET: api/Profile
    [HttpGet]
    public async Task<ActionResult<ProfileDTO>> Get()
    {
      try
      {
        var profiles = await _profileDataService.GetAllProfilesAsync();
        var images = new List<string>();
        foreach (var profile in profiles)
        {
          images.Add(Path.Combine(Directory.GetCurrentDirectory(), profile.ImageModel.Url));
        }

        return Ok(new Response
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
        return BadRequest(new Response { Success = false, ErrorMessage = e.Message });
      }
    }

    // GET: api/Profile/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Response>> Get(int id)
    {
      try
      {
        var profile = await _profileDataService.GetProfileByIdAsync(id);
        return Ok(new Response
        {
          Success = true,
          Data = new ResponseData
          {
            ProfileModels = new List<ProfileDTO> { profile },
            Images = new List<string> { Path.Combine(Directory.GetCurrentDirectory(), profile.ImageModel.Url) }
          }
        });
      }
      catch (Exception e)
      {
        return BadRequest(new Response { Success = false, ErrorMessage = e.Message });
      }
    }

    [HttpGet]
    [Route("ownerid")]
    public async Task<ActionResult<ProfileDTO>> GetProfileByOwnerId()
    {
      try
      {
        return await _profileDataService.GetProfileByOwnerIdAsync(this.User.Identity.Name);
      }
      catch (Exception e)
      {
        return BadRequest(new Response { Success = false, ErrorMessage = e });
      }
    }

    [HttpPut("{id}")]
    [Route("editprofile")]
    public async Task<ActionResult<Response>> EditProfile(ProfileReq input)
    {
      if (ModelState.IsValid)
      {
        try
        {
          var result = await _profileDataService.EditProfileByIdAsync(this.User.Identity.Name, input);

          return Ok(new Response
          {
            Success = true,
            Data = new ResponseData
            {
              ProfileModels = new List<ProfileDTO> { result },
              OfficeModels = new List<OfficeDTO> { await _officeDataService.GetOfficeContainingProfileIdAsync(result.Id) }
            }
          });
        }
        catch (Exception e)
        {
          return BadRequest(new Response { Success = false, ErrorMessage = e.Message });
        }
      }
      return BadRequest(new Response { Success = false, ErrorMessage = ModelState.Values.ToString() });
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
          return Ok(new Response
          {
            Success = true,
            Data = new ResponseData
            {
              ProfileModels = new List<ProfileDTO> { await _profileDataService.GetProfileByOwnerIdAsync(profile.OwnerID) },
              Images = new List<string> { Path.Combine(Directory.GetCurrentDirectory(), profile.ImageModel.Url) }
            }
          });
        }
        return BadRequest(new Response { Success = false, ErrorMessage = "Something went wrong while trying to upload your picture, please try again." });
      }
      catch (Exception e)
      {
        return BadRequest(new Response { Success = false, ErrorMessage = e.Message });
      }
    }

    [HttpPut]
    [Route("UploadResume")]
    public async Task<ActionResult<IFormFile>> UploadResume([FromForm]IFormFile file)
    {
      try
      {
        if (await _profileDataService.ResumeUploadAsync(this.User.Identity.Name, file))
        {
          return Ok(new Response
          {
            Success = true,
            Data = new ResponseData
            {
              ProfileModels = new List<ProfileDTO> { await _profileDataService.GetProfileByOwnerIdAsync(this.User.Identity.Name) }
            }
          });
        }
        return BadRequest(new Response { Success = false, ErrorMessage = "Something went wrong while trying to upload your resumé, please try again." });
      }
      catch (Exception e)
      {
        return BadRequest(new Response { Success = false, ErrorMessage = e.Message });
      }
    }

    //DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Response>> Delete(int id)
    {

      if (await _profileDataService.DeleteProfileAsync(id))
      {
        return Ok(new Response { Success = true });
      }
      return BadRequest(new Response { Success = false, ErrorMessage = _profileDataService.DeleteProfileAsync(id).ToString() });
    }
  }
}
