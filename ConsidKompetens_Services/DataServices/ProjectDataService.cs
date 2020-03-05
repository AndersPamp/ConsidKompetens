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
        return await _dbContext.ProjectModels
          .Include(x => x.ProjectProfileRoles).ThenInclude(p => p.ProfileModel).ThenInclude(p => p.ImageModel)
          .Include(x => x.ProjectProfileRoles).ThenInclude(p => p.RoleModel).Include(p => p.TimePeriod).Include(p => p.Techniques)
          .ToListAsync();
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
        return await _dbContext.ProjectModels.Where(x => x.Name.ToUpper().Contains(input.ToUpper()))
          .Include(x => x.ProjectProfileRoles).ThenInclude(p => p.ProfileModel).ThenInclude(p => p.ImageModel)
          .Include(x => x.ProjectProfileRoles).ThenInclude(p => p.RoleModel)
          .Include(p => p.TimePeriod).Include(p => p.Techniques)
          .ToListAsync();
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
        return await _dbContext.ProjectModels.Include(x => x.ProjectProfileRoles).ThenInclude(p => p.ProfileModel).ThenInclude(p => p.ImageModel)
          .Include(x => x.ProjectProfileRoles).ThenInclude(p => p.RoleModel).Include(p => p.TimePeriod).Include(p => p.Techniques)
          .FirstOrDefaultAsync(x => x.Id == id);
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
        var project = await _dbContext.ProjectModels.Include(x => x.ProjectProfileRoles).ThenInclude(x => x.ProfileModel)
          .Include(x => x.ProjectProfileRoles).ThenInclude(x => x.RoleModel).FirstOrDefaultAsync(x => x.Id == projectModel.Id);

        project.Description = projectModel.Description;
        project.Name = projectModel.Name;
        project.Techniques = projectModel.Techniques;
        project.TimePeriod = projectModel.TimePeriod;
        project.Modified = DateTime.UtcNow;
        project.ProjectProfileRoles = projectModel.ProjectProfileRoles;

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
        projectModel.Created = DateTime.UtcNow;
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
