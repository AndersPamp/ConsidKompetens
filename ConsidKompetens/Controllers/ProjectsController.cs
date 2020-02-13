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

  }
}
