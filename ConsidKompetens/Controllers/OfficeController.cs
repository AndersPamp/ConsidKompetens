using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.CommunicationModels;
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
    public async Task<ActionResult<ResponseModel>> Get([FromBody]List<int> officeIds)
    {
      try
      {
        var response = new ResponseModel
        {
          Success = true,
          Data = new ResponseData
          {
            ProfileModels = await _profileDataService.GetProfilesByOfficeIdsAsync(officeIds),
            OfficeModels = await _officeDataService.GetOfficesByIdsAsync(officeIds)
          }
        };
        return Ok(response);
      }
      catch (Exception e)
      {
        return BadRequest(new ResponseModel { Success = false, ErrorMessage = e.Message });
      }
    }

    [HttpPost]
    public async Task<ActionResult<ResponseModel>> Post([FromBody]OfficeModel officeModel)
    {
      if (ModelState.IsValid)
      {
        try
        {
          await _officeDataService.CreateNewOfficeAsync(officeModel);
          return Created("", new ResponseModel { Success = true, Data = new ResponseData { OfficeModels = await _officeDataService.GetOfficesAsync() } });
        }
        catch (Exception e)
        {
          BadRequest(new ResponseModel { Success= false, ErrorMessage= e.Message });
        }
      }
      return BadRequest(new ResponseModel { Success= false, ErrorMessage= _logger.ToString() });
    }

    [HttpPut]
    public async Task<ActionResult<ResponseModel>> Put([FromBody] OfficeModel officeModel)
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
          BadRequest(new ResponseModel { Success= false, ErrorMessage= e.Message });
        }
      }

      return BadRequest(new ResponseModel { Success= false, ErrorMessage= _logger.ToString() });
    }
  }
}