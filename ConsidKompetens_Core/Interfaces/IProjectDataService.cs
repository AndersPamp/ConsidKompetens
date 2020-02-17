using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.Models;

namespace ConsidKompetens_Services.Interfaces
{
  public interface IProjectDataService
  {
    Task<List<ProjectModel>> GetAllProjectsAsync();
    Task<List<ProjectModel>> GetProjectsByNameAsync(string input);
    Task<ProjectModel> GetProjectByIdAsync(int id);
    Task<ProjectModel> EditProjectAsync(ProjectModel projectModel);
    Task<ProjectModel> CreateNewProjectAsync(ProjectModel projectModel);
  }
}