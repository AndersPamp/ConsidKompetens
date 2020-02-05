using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Web.Communication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsidKompetens_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SearchController : ControllerBase
    {
      private readonly ISearchService _searchService;

      public SearchController(ISearchService searchService)
      {
        _searchService = searchService;
      }

      [HttpGet]
      public ActionResult<List<EmployeeUserModel>> Get(string input)
      {
        try
        {
          return null;
        }
        catch (Exception e)
        {
          return BadRequest(new JsonResponse {Ok = false, Message = e.Message});
        }
      }
    }
}