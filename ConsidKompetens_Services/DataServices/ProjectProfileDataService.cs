using System;
using System.Linq;
using System.Threading.Tasks;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ConsidKompetens_Services.DataServices
{
  public class ProjectProfileDataService : IProjectProfileDataService
  {
    private readonly DataDbContext _dbContext;
    private readonly ILogger<ProjectProfileDataService> _logger;

    public ProjectProfileDataService(ILogger<ProjectProfileDataService> logger, DataDbContext dbContext)
    {
      _logger = logger;
      _dbContext = dbContext;
    }

    public async Task<ProjectProfileRole> CreateProfileRoleAsync(int projectId, int profileId, RoleModel role)
    {
      try
      {
        var newRole = new ProjectProfileRole
        {
          ProjectId = projectId,
          ProfileId = profileId,
          Role = role
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

    public async Task<ProjectProfileRole> EditProfileRoleAsync(int projectId, int profileId, RoleModel role)
    {
      try
      {
        var deltaRole = await _dbContext.ProjectProfileRoles.Where(x => x.ProjectId == projectId && x.ProfileId == profileId)
          .FirstOrDefaultAsync();
        deltaRole.ProjectId = projectId;
        deltaRole.ProfileId = profileId;
        deltaRole.Role = role;

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