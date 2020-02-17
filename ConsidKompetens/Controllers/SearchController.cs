using System;
using System.Collections.Generic;
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
    public ActionResult<List<ProfileModel>> Search(string input)
    {
      try
      {
        return null;
      }
      catch (Exception e)
      {
        return BadRequest(new SpaPageModel { Ok = false, Message = e.Message });
      }
    }
  }
}