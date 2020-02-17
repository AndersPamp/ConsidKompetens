using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Data.Data;
using ConsidKompetens_Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConsidKompetens_Services.DataServices
{
  public class ProjectDataService : IProjectDataService
  {
    private readonly DataDbContext _dbContext;

    public ProjectDataService(DataDbContext dbContext)
    {
      _dbContext = dbContext;
    }
    public async Task<List<ProjectModel>> GetAllProjectsAsync()
    {
      try
      {
        return await _dbContext.ProjectModels.Include(x=>x.ProfileModels).ToListAsync();
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<List<ProjectModel>> GetProjectsByNameAsync(string input)
    {
      try
      {
        return await _dbContext.ProjectModels.Where(x => x.Name.ToUpper().Contains(input.ToUpper())).Include(x=>x.ProfileModels).ToListAsync();
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
        return await _dbContext.ProjectModels.Include(x=>x.ProfileModels).FirstOrDefaultAsync(x => x.Id == id);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<ProjectModel> EditProjectAsync(ProjectModel projectModel)
    {
      try
      {
        var project = await _dbContext.ProjectModels.FindAsync(projectModel.Id);
        project.Description = projectModel.Description;
        project.Name = projectModel.Name;
        project.Roles = projectModel.Roles;
        project.Techniques = projectModel.Techniques;
        project.TimePeriod = projectModel.TimePeriod;
        project.ProfileModels = projectModel.ProfileModels;
        await _dbContext.SaveChangesAsync();
        return projectModel;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<ProjectModel> CreateNewProjectAsync(ProjectModel projectModel)
    {
      try
      {
        await _dbContext.ProjectModels.AddAsync(projectModel);
        await _dbContext.SaveChangesAsync();
        return projectModel;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
  }
}
