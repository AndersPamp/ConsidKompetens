using System;
using System.Collections.Generic;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Services.Interfaces;
using ConsidKompetens_Web.Communication;
using Microsoft.AspNetCore.Mvc;

namespace ConsidKompetens_Web.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeeController : ControllerBase
  {
    private readonly IUserDataService _userDataService;
    private readonly ISearchService _searchService;

    public EmployeeController(IUserDataService userDataService, ISearchService searchService)
    {
      _userDataService = userDataService;
      _searchService = searchService;
    }

    // GET: api/Employee
    [HttpGet]
    public ActionResult<IEnumerable<EmployeeUserModel>> Get()
    {
      try
      {
        var users = _userDataService.GetAllUsersAsync().Result;
        return Ok(new JsonResponse { Ok = true, Data = users, TotalHits = users.Count });
      }
      catch (Exception e)
      {
        return BadRequest(new JsonResponse { Ok = false, Message = e.Message });
      }
    }

    // GET: api/Employee/5
    [HttpGet("{id}", Name = "Get")]
    public ActionResult<EmployeeUserModel> Get(Guid id)
    {
      try
      {
        var user = _userDataService.GetUserByIdAsync(id).Result;
        return Ok(new JsonResponse{Ok = true, Data = user});
      }
      catch (Exception e)
      {
        return BadRequest(new JsonResponse { Ok = false, Message = e.Message });
      }

      ;
    }

    // POST: api/Employee

    //[HttpPost]
    //public void Post([FromBody] string value)
    //{
    //}

    // PUT: api/Employee/5
    [HttpPut("{id}")]
    public ActionResult<bool> Put(Guid id, [FromBody] EmployeeUserModel value)
    {
      if (ModelState.IsValid)
      {
        try
        {
          var result = _userDataService.EditUserByIdAsync(id, value).Result;
          return Ok(new JsonResponse{Ok = true, Data = result, Message = "Profile has been updated"});
        }
        catch (Exception e)
        {
          return BadRequest(new JsonResponse {Ok = false, Message = e.Message});
        }
      }
      return BadRequest(new JsonResponse { Ok = false, Message = "Model input not correct" });
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
