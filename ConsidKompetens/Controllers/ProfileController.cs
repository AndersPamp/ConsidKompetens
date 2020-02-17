using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Core.Models;
using Microsoft.AspNetCore.Authorization;
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
    public async Task<ActionResult<SpaPageModel>> Get()
    {
      try
      {
        var profiles = await _profileDataService.GetAllProfilesAsync();
        return Ok(new SpaPageModel() { PageTitle = "AllProfiles", Ok = true, Consultants = profiles });
      }
      catch (Exception e)
      {
        return BadRequest(new SpaPageModel{ PageTitle = "Profiles", Ok = false, Message = e.Message });
      }
    }

    // GET: api/Profile/5
    [HttpGet("{id}")]
    public async Task<ActionResult<SpaPageModel>> Get(int id)
    {
      try
      {
        var user = await _profileDataService.GetProfileByIdAsync(id);
        return Ok(new SpaPageModel { PageTitle = user.FirstName + user.LastName, Ok = true, Consultants = new List<ProfileModel> { user } });
      }
      catch (Exception e)
      {
        return BadRequest(new SpaPageModel{PageTitle = "Profiles", Ok = false, Message = e.Message });
      }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<SpaPageModel>> Put([FromBody] ProfileModel value)
    {
      if (ModelState.IsValid)
      {
        try
        {
          var userId = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;

          var profile = await _profileDataService.GetProfileByOwnerIdAsync(userId);
          var result = await _profileDataService.EditProfileByIdAsync(profile.Id, value);

          return Ok(new SpaPageModel { PageTitle = result.FirstName + result.LastName, Ok = true, Consultants = new List<ProfileModel> { result } });
        }
        catch (Exception e)
        {
          return BadRequest(new SpaPageModel{ PageTitle = "Profiles", Ok = false, Message = e.Message });
        }
      }
      return BadRequest(new SpaPageModel{PageTitle = "Profiles", Ok = false, Message = _logger.ToString()});
    }

    // DELETE: api/ApiWithActions/5
    //[HttpDelete("{id}")]
    //public Task<ActionResult<SpaPageModel>> Delete(int id)
    //{
    //  return null;
    //}
  }
}
