using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public async Task<ActionResult<IEnumerable<OfficeModel>>> Get([FromBody]List<int> officeIds)
    {
      try
      {
        var spa=new SpaPageModel
        {
          Ok = true,
          PageTitle = "Offices",
          Consultants = await _profileDataService.GetProfilesByOfficeIdsAsync(officeIds)
        };
        return Ok(await _officeDataService.GetOfficesByIdsAsync(officeIds));
      }
      catch (Exception e)
      {
        return BadRequest(_logger+ e.Message);
      }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody]OfficeModel officeModel)
    {
      if (ModelState.IsValid)
      {
        try
        {
          await _officeDataService.CreateNewOfficeAsync(officeModel);
          return Created("", officeModel);
        }
        catch (Exception e)
        {
          BadRequest(_logger + e.Message);
        }
      }
      return BadRequest(_logger);
    }

    [HttpPut]
    public async Task<ActionResult<OfficeModel>> Put([FromBody] OfficeModel officeModel)
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
          BadRequest(_logger + e.Message);
        }
      }

      return BadRequest(_logger);
    }
  }
}