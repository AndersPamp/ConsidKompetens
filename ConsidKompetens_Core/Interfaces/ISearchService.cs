using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.Models;

namespace ConsidKompetens_Core.Interfaces
{
  public interface ISearchService
  {
    Task<List<OfficeModel>> GetSelectedOfficesAsync(List<int> selectedOffices);
    Task<List<EmployeeUserModel>> GetUsersByCompetenceAsync(int competenceId);
    Task<List<EmployeeUserModel>> GetUsersByNameAsync(string input);
  }
}