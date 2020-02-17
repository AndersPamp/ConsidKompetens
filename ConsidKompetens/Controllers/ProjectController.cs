using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConsidKompetens_Web.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class ProjectController : ControllerBase
  {
    private readonly IProjectDataService _projectService;
    private readonly ILogger<ProjectController> _logger;

    public ProjectController(IProjectDataService projectService, ILogger<ProjectController> logger)
    {
      _projectService = projectService;
      _logger = logger;
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
          PageTitle = "Project",
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

      return BadRequest(new SpaPageModel { PageTitle = "Projects", Ok = false, Message = _logger.ToString()});
    }

    [HttpPut]
    public async Task<ActionResult<SpaPageModel>> Put(ProjectModel projectModel)
    {
      if (ModelState.IsValid)
      {
        try
        {
          var deltaProjects = new List<ProjectModel>{ await _projectService.EditProjectAsync(projectModel) };

          return new SpaPageModel{PageTitle = "Projects", Ok = true, Projects = deltaProjects};
        }
        catch (Exception e)
        {
          return BadRequest(new SpaPageModel { PageTitle = "Projects", Ok = false, Message = e.Message });
        }
      }
      return BadRequest(new SpaPageModel { PageTitle = "Projects", Ok = false, Message = _logger.ToString() });
    }
  }
}
