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

    {
      _dbContext = dbContext;
    public ProjectDataService(DataDbContext dbContext)
    }
    public async Task<IEnumerable<ProjectModel>> GetAllProjectsAsync()
    {
      try
      {
        return await _dbContext.ProjectModels.ToListAsync();
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
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
        throw new Exception(e.Message);
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
        throw new Exception(e.Message);
      }
    }
  }
}
