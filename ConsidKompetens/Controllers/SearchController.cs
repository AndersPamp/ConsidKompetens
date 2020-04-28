using System;
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

    [HttpPost]
    //[OutputCache(Duration = 30)]
    public async Task<ActionResult<Response>> Search([FromBody]SearchRequest request)
    {
      //return await _searchService.FreeWordSearcAsync(request.OfficeIds, request.Input);
      //In js use Debounce with input delay
      try
      {
        return Ok(await _searchService.FreeWordSearcAsync(request.OfficeIds, request.Input));
      }
      catch (Exception e)
      {
        return BadRequest(new Response { Success= false, ErrorMessage= e.Message });
      }
    }
  }
}