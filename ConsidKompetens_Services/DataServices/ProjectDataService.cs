using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ConsidKompetens_Core.DTO;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Data.Data;
using ConsidKompetens_Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConsidKompetens_Services.DataServices
{
  public class ProjectDataService : IProjectDataService
  {
    private readonly DataDbContext _dbContext;
    private readonly IMapper _mapper;

    public ProjectDataService(DataDbContext dbContext, IMapper mapper)
    {
      _dbContext = dbContext;
      _mapper = mapper;
    }
    public async Task<List<ProjectDTO>> GetAllProjectsAsync()
    {
      try
      {
        var projects = await _dbContext.ProjectModels
          .Include(x => x.ProjectProfileRoles).ThenInclude(p => p.ProfileModel).ThenInclude(p => p.ImageModel)
          .Include(x => x.ProjectProfileRoles).ThenInclude(p => p.RoleModel).Include(p => p.TimePeriod).Include(p => p.Techniques)
          .ToListAsync();

        return _mapper.Map<List<ProjectModel>, List<ProjectDTO>>(projects);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<List<ProjectDTO>> GetProjectsByNameAsync(string input)
    {
      try
      {
        var projects = await _dbContext.ProjectModels.Where(x => x.Name.ToUpper().Contains(input.ToUpper()))
          .Include(x => x.ProjectProfileRoles).ThenInclude(p => p.ProfileModel).ThenInclude(p => p.ImageModel)
          .Include(x => x.ProjectProfileRoles).ThenInclude(p => p.RoleModel)
          .Include(p => p.TimePeriod).Include(p => p.Techniques)
          .ToListAsync();

        return _mapper.Map<List<ProjectModel>, List<ProjectDTO>>(projects);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<ProjectDTO> GetProjectByIdAsync(int id)
    {
      try
      {
        var project = await _dbContext.ProjectModels.Include(x => x.ProjectProfileRoles).ThenInclude(p => p.ProfileModel).ThenInclude(p => p.ImageModel)
          .Include(x => x.ProjectProfileRoles).ThenInclude(p => p.RoleModel).Include(p => p.TimePeriod).Include(p => p.Techniques)
          .FirstOrDefaultAsync(x => x.Id == id);

        return _mapper.Map<ProjectModel, ProjectDTO>(project);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<ProjectDTO> EditProjectAsync(ProjectModel projectModel)
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
        return _mapper.Map<ProjectModel, ProjectDTO>(project);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<ProjectDTO> CreateNewProjectAsync(ProjectModel projectModel)
    {
      try
      {
        projectModel.Created = DateTime.UtcNow;
        await _dbContext.ProjectModels.AddAsync(projectModel);
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<ProjectModel, ProjectDTO>(projectModel);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
  }
}
