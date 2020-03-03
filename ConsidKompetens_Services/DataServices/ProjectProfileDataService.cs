using System;
using System.Linq;
using System.Threading.Tasks;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Data.Data;
using Microsoft.EntityFrameworkCore;

namespace ConsidKompetens_Services.DataServices
{
  public class ProjectProfileDataService : IProjectProfileDataService
  {
    private readonly DataDbContext _dbContext;

    public ProjectProfileDataService(DataDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<ProjectProfileRole> CreateProfileRoleAsync(int projectId, int profileId, int roleId)
    {
      try
      {
        var newRole = new ProjectProfileRole
        {
          ProjectModelId = projectId,
          ProfileModelId = profileId,
          RoleModelId = roleId
        };

        await _dbContext.ProjectProfileRoles.AddAsync(newRole);
        await _dbContext.SaveChangesAsync();
        return newRole;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<ProjectProfileRole> EditProfileRoleAsync(int projectId, int profileId, int roleId)
    {
      try
      {
        var deltaRole = await _dbContext.ProjectProfileRoles.Where(x => x.ProjectModelId == projectId && x.ProfileModelId == profileId && x.RoleModelId == roleId)
          .FirstOrDefaultAsync();
        deltaRole.ProjectModelId = projectId;
        deltaRole.ProfileModelId = profileId;
        deltaRole.RoleModelId = roleId;

        await _dbContext.SaveChangesAsync();
        return deltaRole;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
  }
}