using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.Models;

namespace ConsidKompetens_Services.Interfaces
{
  public interface IProjectDataService
  {
    Task<IEnumerable<ProjectModel>> GetAllProjectsAsync();
    Task<IEnumerable<ProjectModel>> GetProjectsByNameAsync(string input);
    Task<ProjectModel> GetProjectByIdAsync(int id);
  }
}