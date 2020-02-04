using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.Models;

namespace ConsidKompetens_Services.Interfaces
{
  public interface ISearchService
  {
    Task<List<OfficeModel>> GetSelectedOfficesAsync(List<Guid> selectedOffices);
    Task<List<EmployeeUserModel>> GetUsersByCompetenceAsync(Guid competenceId);
    Task<List<EmployeeUserModel>> GetUsersByNameAsync(string name);
  }
}