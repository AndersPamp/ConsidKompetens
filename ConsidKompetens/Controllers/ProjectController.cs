using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.CommunicationModels;
using ConsidKompetens_Core.Interfaces;
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
    private readonly IProjectProfileDataService _projectProfileDataService;

    public ProjectController(IProjectDataService projectService, ILogger<ProjectController> logger, IProjectProfileDataService projectProfileDataService)
    {
      _projectService = projectService;
      _logger = logger;
      _projectProfileDataService = projectProfileDataService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ResponseModel>>> Get()
    {
      try
      {
        return Ok(await _projectService.GetAllProjectsAsync());
      }
      catch (Exception e)
      {
        return BadRequest(new ResponseModel { Success = false, ErrorMessage = e.Message });
      }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ResponseModel>> Get(int id)
    {
      try
      {
        var deltaList = new List<ProjectModel> { await _projectService.GetProjectByIdAsync(id) };
        return Ok(new ResponseModel
        {
          Success = true,
          Data = new ResponseData { ProjectModels = deltaList }
        });
      }
      catch (Exception e)
      {
        return BadRequest(new ResponseModel { Success = false, ErrorMessage = e.Message });
      }
    }

    [HttpPost]
    public async Task<ActionResult<ResponseModel>> Post(ProjectModel projectModel)
    {
      if (ModelState.IsValid)
      {
        await _projectService.CreateNewProjectAsync(projectModel);
        return Ok(new ResponseModel { Success = true, Data = new ResponseData { ProjectModels = await _projectService.GetAllProjectsAsync()}});
      }

      return BadRequest(new ResponseModel { Success= false, ErrorMessage= _logger.ToString() });
    }

    [HttpPut]
    public async Task<ActionResult<ResponseModel>> Put(ProjectModel projectModel)
    {
      if (ModelState.IsValid)
      {
        try
        {
          var deltaProjects = new List<ProjectModel> { await _projectService.EditProjectAsync(projectModel) };

          return new ResponseModel { Success= true, Data = new ResponseData{ProjectModels = deltaProjects}};
        }
        catch (Exception e)
        {
          return BadRequest(new ResponseModel { Success= false, ErrorMessage= e.Message });
        }
      }
      return BadRequest(new ResponseModel { Success= false, ErrorMessage= _logger.ToString() });
    }
  }
}
