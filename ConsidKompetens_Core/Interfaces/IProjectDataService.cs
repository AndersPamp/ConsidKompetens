using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.DTO;
using ConsidKompetens_Core.Models;

namespace ConsidKompetens_Services.Interfaces
{
  public interface IProjectDataService
  {
    Task<List<ProjectDTO>> GetAllProjectsAsync();
    Task<List<ProjectDTO>> GetProjectsByNameAsync(string input);
    Task<ProjectDTO> GetProjectByIdAsync(int id);
    Task<ProjectDTO> EditProjectAsync(ProjectModel projectModel);
    Task<ProjectDTO> CreateNewProjectAsync(ProjectModel projectModel);
  }
}