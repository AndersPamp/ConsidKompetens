using System;
using System.Threading.Tasks;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Core.Models;
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
    public async Task<ActionResult<ResponseModel>> Search(string input)
    {
      //In js Debounce with input delay
      try
      {
        return await _searchService.FreeWordSearcAsync(input);
      }
      catch (Exception e)
      {
        return BadRequest(new ResponseModel { Success= false, ErrorMessage= e.Message });
      }
    }
  }
}