using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Core.Response_Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConsidKompetens_Web.Controllers
{
  [Route("api/[controller]")]
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
    public async Task<ActionResult<Response>> Search(List<int> officeIds, string input)
    {
      //In js Debounce with input delay
      try
      {
        return await _searchService.FreeWordSearcAsync(officeIds, input);
      }
      catch (Exception e)
      {
        return BadRequest(new Response { Success= false, ErrorMessage= e.Message });
      }
    }
  }
}