using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Core.Models;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConsidKompetens_Web.Controllers
{
  [Route("api/[controller]/[action]")]
  [ApiController]
  [Authorize]
  public class SearchController : ControllerBase
  {
    private readonly ISearchDataService _searchService;

    public SearchController(ISearchDataService searchService)
    {
      _searchService = searchService;
    }

    [HttpGet]
    [OutputCache(Duration = 30)]
    public async Task<ActionResult<SpaPageModel>> Search(string input)
    {
      //In js Debounce with input delay
      var spa = new SpaPageModel();
      try
      {
        var result = await _searchService.FreeWordSearcAsync(input);
        if (!result.IsNullOrEmpty())
        {
          spa.PageTitle = "Search";
          spa.Ok = true;
          spa.Consultants = result;
        }
        spa.PageTitle = "Search";
        spa.Ok = false;
        spa.Consultants = result;
        spa.Message = "None found";
        return spa;
      }
      catch (Exception e)
      {
        return BadRequest(new SpaPageModel { Ok = false, Message = e.Message });
      }
    }
  }
}