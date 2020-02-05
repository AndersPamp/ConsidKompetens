using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Data.Data;
using ConsidKompetens_Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConsidKompetens_Services.DataServices
{
  public class SearchService : ISearchService
  {
    private readonly UserDataContext _userDataContext;

    public SearchService(UserDataContext userDataContext)
    {
      _userDataContext = userDataContext;
    }
    public async Task<List<OfficeModel>> GetSelectedOfficesAsync(List<int> selectedOfficeIds)
    {
      try
      {
        var selectedOffices = new List<OfficeModel>();
        foreach (var officeId in selectedOfficeIds)
        {
          var officeDelta = await _userDataContext.OfficeModels.FindAsync(officeId);
          selectedOffices.Add(officeDelta);
        }
        return selectedOffices;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public Task<List<EmployeeUserModel>> GetUsersByCompetenceAsync(int competenceId)
    {
      throw new NotImplementedException();
    }

    public Task<List<EmployeeUserModel>> GetUsersByNameAsync(string name)
    {
      throw new NotImplementedException();
    }
  }
}