using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsidKompetens_Web.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class ProjectsController : ControllerBase
  {
    private readonly IProjectDataService _projectService;

    public ProjectsController(IProjectDataService projectService)
    {
      _projectService = projectService;
    }

    [HttpGet]
    public async Task<ActionResult<List<SpaPageModel>>> Get()
    {
      try
      {
        return Ok(await _projectService.GetAllProjectsAsync());
      }
      catch (Exception e)
      {
        return BadRequest(new SpaPageModel { PageTitle = "Projects", Ok = false, Message = e.Message });
      }
    }

   
    [HttpGet("{id}")]
    public async Task<ActionResult<SpaPageModel>> Get(int id)
    {
      try
      {
        var deltaList = new List<ProjectModel> { await _projectService.GetProjectByIdAsync(id) };
        return Ok(new SpaPageModel
        {
          PageTitle = "Projects",
          Ok = true,
          Projects = deltaList
        });
      }
      catch (Exception e)
      {
        return BadRequest(new SpaPageModel { PageTitle = "Projects", Ok = false, Message = e.Message });
      }
    }

    [HttpPost]
    public async Task<ActionResult<SpaPageModel>> Post(ProjectModel projectModel)
    {
      if (ModelState.IsValid)
      {
        await _projectService.CreateNewProjectAsync(projectModel);
        return Ok(new SpaPageModel { PageTitle = "Projects", Ok = true, Projects = await _projectService.GetAllProjectsAsync() });
      }

      return BadRequest(new SpaPageModel { PageTitle = "Projects", Ok = false });
    }

    [HttpPut]
    public async Task<ActionResult<SpaPageModel>> Put(ProjectModel projectModel)
    {
      try
      {
        return null;
      }
      catch (Exception e)
      {
        return BadRequest(new SpaPageModel { PageTitle = "Projects", Ok = false, Message = e.Message });
      }
    }
  }
}
