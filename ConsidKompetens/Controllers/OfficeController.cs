using System;
using System.Collections.Generic;
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
  public class OfficeController : ControllerBase
  {
    private readonly IOfficeDataService _officeDataService;
    private readonly IProfileDataService _profileDataService;
    private readonly ILogger<OfficeController> _logger;

    public OfficeController(IOfficeDataService officeDataService, IProfileDataService profileDataService, ILogger<OfficeController> logger)
    {
      _officeDataService = officeDataService;
      _profileDataService = profileDataService;
      _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<SpaPageModel>> Get([FromBody]List<int> officeIds)
    {
      try
      {
        var spa = new SpaPageModel
        {
          Ok = true,
          PageTitle = "Offices",
          Consultants = await _profileDataService.GetProfilesByOfficeIdsAsync(officeIds),
          Framework = { Offices = await _officeDataService.GetOfficesByIdsAsync(officeIds) }
        };
        return Ok(spa);
      }
      catch (Exception e)
      {
        return BadRequest(new SpaPageModel{PageTitle = "Offices", Ok = false, Message = e.Message});
      }
    }

    [HttpPost]
    public async Task<ActionResult<SpaPageModel>> Post([FromBody]OfficeModel officeModel)
    {
      if (ModelState.IsValid)
      {
        try
        {
          await _officeDataService.CreateNewOfficeAsync(officeModel);
          return Created("", new SpaPageModel{PageTitle = "Offices", Ok = true, Framework = {Offices = await _officeDataService.GetOfficesAsync()}});
        }
        catch (Exception e)
        {
          BadRequest(new SpaPageModel{PageTitle = "Offices", Ok = false, Message = e.Message});
        }
      }
      return BadRequest(new SpaPageModel{PageTitle = "Offices", Ok = false, Message = _logger.ToString()});
    }

    [HttpPut]
    public async Task<ActionResult<SpaPageModel>> Put([FromBody] OfficeModel officeModel)
    {
      if (ModelState.IsValid)
      {
        try
        {
          await _officeDataService.EditOfficeAsync(officeModel);
          return Created("", officeModel);
        }
        catch (Exception e)
        {
          BadRequest(new SpaPageModel { PageTitle = "Offices", Ok = false, Message = e.Message });
        }
      }

      return BadRequest(new SpaPageModel { PageTitle = "Offices", Ok = false, Message = _logger.ToString() });
    }
  }
}