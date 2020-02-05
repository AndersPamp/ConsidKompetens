using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.Models;

namespace ConsidKompetens_Services.Interfaces
{
  public interface ISearchService
  {
    Task<List<EmployeeUserModel>> GetSelectedOfficesAsync(List<int> selectedOffices);
    Task<List<EmployeeUserModel>> GetUsersByCompetenceAsync(int competenceId);
    Task<List<EmployeeUserModel>> GetUsersByNameAsync(string input);
  }
}