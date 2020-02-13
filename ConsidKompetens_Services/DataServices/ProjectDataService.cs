using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Data.Data;
using ConsidKompetens_Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ConsidKompetens_Services.DataServices
{
  public class ProjectDataService : IProjectDataService
  {
    private readonly DataDbContext _dbContext;
<<<<<<< HEAD

    public ProjectDataService(DataDbContext dbContext)
    {
      _dbContext = dbContext;
=======
    private readonly ILogger<IProjectDataService> _logger;

    public ProjectDataService(DataDbContext dbContext, ILogger<IProjectDataService> logger)
    {
      _dbContext = dbContext;
      _logger = logger;
>>>>>>> Add Officemodel logic
    }
    public async Task<IEnumerable<ProjectModel>> GetAllProjectsAsync()
    {
      try
      {
        return await _dbContext.ProjectModels.ToListAsync();
      }
      catch (Exception e)
      {
<<<<<<< HEAD
        throw new Exception(e.Message);
=======
        throw new Exception(_logger + e.Message);
>>>>>>> Add Officemodel logic
      }
    }

    public async Task<IEnumerable<ProjectModel>> GetProjectsByNameAsync(string input)
    {
      try
      {
        return await _dbContext.ProjectModels.Where(x => x.Name.ToUpper().Contains(input.ToUpper())).ToListAsync();
      }
      catch (Exception e)
      {
<<<<<<< HEAD
        throw new Exception(e.Message);
=======
        throw new Exception(_logger + e.Message);
>>>>>>> Add Officemodel logic
      }
    }

    public async Task<ProjectModel> GetProjectByIdAsync(int id)
    {
      try
      {
        return await _dbContext.ProjectModels.FirstOrDefaultAsync(x => x.Id == id);
      }
      catch (Exception e)
      {
<<<<<<< HEAD
        throw new Exception(e.Message);
=======
        throw new Exception(_logger + e.Message);
>>>>>>> Add Officemodel logic
      }
    }
  }
}