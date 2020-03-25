using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.DTO;
using ConsidKompetens_Core.Models;

namespace ConsidKompetens_Services.Interfaces
{
  public interface IProjectDataService
  {
    Task<List<ProjectDto>> GetAllProjectsAsync();
    Task<List<ProjectDto>> GetProjectsByNameAsync(string input);
    Task<ProjectDto> GetProjectByIdAsync(int id);
    Task<ProjectDto> EditProjectAsync(ProjectModel projectModel);
    Task<ProjectDto> CreateNewProjectAsync(ProjectModel projectModel);
  }
}