using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Core.Response_Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
    [Route("Offices")]
    public async Task<ActionResult<Response>> GetAllOffices()
    {
      try
      {
        return Ok(new Response { Success = true, Data = new ResponseData { OfficeModels = await _officeDataService.GetOfficesAsync() } });
      }
      catch (Exception e)
      {
        return BadRequest(new Response { Success = false, ErrorMessage = e });
      }
    }

    [HttpGet]
    [Route("Profiles")]
    public async Task<ActionResult<Response>> GetOfficesByIds(string officeIds)
    {
      try
      {
        var splitString = officeIds.Split(',');
        var intArray = splitString.Select(digit => int.Parse(digit)).ToList();
        //var intOnlyString = new string(officeIds.ToCharArray().Where(c=>char.IsDigit(c)).ToArray());
        //var intArray = intOnlyString.Select(digit => int.Parse(digit.ToString())).ToList();
        var response = new Response
        {
          Success = true,
          Data = new ResponseData
          {
            ProfileModels = await _profileDataService.GetProfilesByOfficeIdsAsync(intArray),
            OfficeModels = await _officeDataService.GetOfficesByIdsAsync(intArray)
          }
        };
        return Ok(response);
      }
      catch (Exception e)
      {
        return BadRequest(new Response { Success = false, ErrorMessage = e.Message });
      }
      
    }
    /*[HttpPost]
    [Route("Profiles")]
    public async Task<ActionResult<Response>> PostOfficesByIds([FromBody]OfficeReq officeIds)
    {
      try
      {
        var response = new Response
        {
          Success = true,
          Data = new ResponseData
          {
            ProfileModels = await _profileDataService.GetProfilesByOfficeIdsAsync(officeIds.OfficeIds),
            OfficeModels = await _officeDataService.GetOfficesByIdsAsync(officeIds.OfficeIds)
          }
        };
        return Ok(response);
      }
      catch (Exception e)
      {
        return BadRequest(new Response { Success = false, ErrorMessage = e.Message });
      }
    }*/

    [HttpPost]
    public async Task<ActionResult<Response>> Post([FromBody]OfficeModel officeModel)
    {
      if (ModelState.IsValid)
      {
        try
        {
          await _officeDataService.CreateNewOfficeAsync(officeModel);
          return Created("", new Response { Success = true, Data = new ResponseData { OfficeModels = await _officeDataService.GetOfficesAsync() } });
        }
        catch (Exception e)
        {
          BadRequest(new Response { Success = false, ErrorMessage = e.Message });
        }
      }
      return BadRequest(new Response { Success = false, ErrorMessage = _logger.ToString() });
    }

    [HttpPut]
    public async Task<ActionResult<Response>> Put([FromBody] OfficeModel officeModel)
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
          BadRequest(new Response { Success = false, ErrorMessage = e.Message });
        }
      }

      return BadRequest(new Response { Success = false, ErrorMessage = _logger.ToString() });
    }
  }
}