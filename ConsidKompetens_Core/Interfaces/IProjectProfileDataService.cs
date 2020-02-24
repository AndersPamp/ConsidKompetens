using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ConsidKompetens_Core.Models;

namespace ConsidKompetens_Core.Interfaces
{
  public interface IProjectProfileDataService
  {
    Task<ProjectProfileRole> CreateProfileRoleAsync(int projectId, int profileId, RoleModel role);
    Task<ProjectProfileRole> EditProfileRoleAsync(int projectId, int profileId, RoleModel role);
  }
}
