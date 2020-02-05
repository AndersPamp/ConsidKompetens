using System;
using System.Collections.Generic;
using System.Linq;
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
          var officeDelta = await _userDataContext.OfficeModels.Include(x => x.Employees).FirstOrDefaultAsync(x => x.Id == officeId);
          selectedOffices.Add(officeDelta);
        }
        return selectedOffices;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<List<EmployeeUserModel>> GetUsersByCompetenceAsync(int competenceId)
    {
      try
      {
        var emps = await _userDataContext.EmployeeUsers.Include(c => c.Competences)
          .Include(p => p.Projects).ToListAsync();
        var empsDelta = new List<EmployeeUserModel>();
        foreach (var emp in emps)
        {
          if (emp.CompetenceIds.Contains(competenceId))
          {
            empsDelta.Add(emp);
          }
        }
        return empsDelta;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<List<EmployeeUserModel>> GetUsersByNameAsync(string input)
    {
      try
      {
        var allEmps = await _userDataContext.EmployeeUsers.Include(x => x.Competences).ToListAsync();

        var resultFirst = allEmps.Where(x => x.FirstName.ToUpper().Contains(input.ToUpper()));
        var resultLast = allEmps.Where(x => x.LastName.ToUpper().Contains(input.ToUpper()));
        var result = new List<EmployeeUserModel>();
        foreach (var first in resultFirst)
        {
          result.Add(first);
        }

        foreach (var last in resultLast)
        {
          result.Add(last);
        }

        return result;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
  }
}