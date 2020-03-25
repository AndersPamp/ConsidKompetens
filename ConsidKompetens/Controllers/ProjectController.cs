using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.DTO;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Core.Response_Request;
using ConsidKompetens_Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConsidKompetens_Web.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class ProjectController : ControllerBase
  {
    private readonly IProjectDataService _projectService;

    public ProjectController(IProjectDataService projectService)
    {
      _projectService = projectService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Response>>> Get()
    {
      try
      {
        return Ok(await _projectService.GetAllProjectsAsync());
      }
      catch (Exception e)
      {
        return BadRequest(new Response { Success = false, ErrorMessage = e.Message });
      }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Response>> Get(int id)
    {
      try
      {
        var deltaList = new List<ProjectDto> { await _projectService.GetProjectByIdAsync(id) };
        return Ok(new Response
        {
          Success = true,
          Data = new ResponseData { ProjectModels = deltaList }
        });
      }
      catch (Exception e)
      {
        return BadRequest(new Response { Success = false, ErrorMessage = e.Message });
      }
    }

    [HttpPost]
    public async Task<ActionResult<Response>> Post(ProjectModel projectModel)
    {
      if (ModelState.IsValid)
      {
        var result = await _projectService.CreateNewProjectAsync(projectModel);
        return Ok(new Response { Success = true, Data = new ResponseData { ProjectModels = await _projectService.GetAllProjectsAsync()}});
      }

      return BadRequest(new Response { Success= false, ErrorMessage= ModelState});
    }

    [HttpPut]
    public async Task<ActionResult<Response>> Put(ProjectModel projectModel)
    {
      if (ModelState.IsValid)
      {
        try
        {
          var deltaProjects = new List<ProjectDto> { await _projectService.EditProjectAsync(projectModel) };

          return new Response { Success= true, Data = new ResponseData{ProjectModels = deltaProjects}};
        }
        catch (Exception e)
        {
          return BadRequest(new Response { Success= false, ErrorMessage= e.Message });
        }
      }
      return BadRequest(new Response { Success= false, ErrorMessage= ModelState});
    }
  }
}
