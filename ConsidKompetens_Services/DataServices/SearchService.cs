using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Services.Interfaces;

namespace ConsidKompetens_Services.DataServices
{
  public class SearchService:ISearchService
  {
    public Task<List<OfficeModel>> GetSelectedOfficesAsync(List<Guid> selectedOffices)
    {
      throw new NotImplementedException();
    }

    public Task<List<EmployeeUserModel>> GetUsersByCompetenceAsync(Guid competenceId)
    {
      throw new NotImplementedException();
    }

    public Task<List<EmployeeUserModel>> GetUsersByNameAsync(string name)
    {
      throw new NotImplementedException();
    }
  }
}