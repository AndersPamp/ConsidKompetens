using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Data.Data;
using IdentityServer4.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ConsidKompetens_Services.DataServices
{
  public class SearchService : ISearchDataService
  {
    private readonly DataDbContext _userDataContext;

    public SearchService(DataDbContext userDataContext)
    {
      _userDataContext = userDataContext;
    }

    public async Task<List<ProfileModel>> GetAllProfiles()
    {
      try
      {
        return await _userDataContext.ProfileModels.Include(x=>x.Competences)
          .Include(x=>x.Projects).Include(x=>x.ProfileImage).ToListAsync();
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
    public async Task<List<OfficeModel>> GetSelectedOfficesAsync(List<int> selectedOfficeIds)
    {
      var result = new List<OfficeModel>();
      if (selectedOfficeIds.IsNullOrEmpty())
      {
        return await _userDataContext.OfficeModels.ToListAsync();
      }
      try
      {
        
        foreach (var officeId in selectedOfficeIds)
        {
          var officeDelta = await _userDataContext.OfficeModels.Include(x => x.Employees).FirstOrDefaultAsync(x => x.Id == officeId);
          result.Add(officeDelta);
        }
        return result;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
    public async Task<List<ProfileModel>> GetProfilesByCompetenceAsync(int competenceId)
    {
      try
      {
        var competence = await _userDataContext.CompetenceModels.FirstOrDefaultAsync(x => x.Id == competenceId);
        var users = await GetAllProfiles();
        var result = new List<ProfileModel>();

        foreach (var user in users)
        {
          if (user.Competences.Contains(competence))
          {
            result.Add(user);
          }
        }

        return result;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
    public async Task<List<ProfileModel>> GetProfilesByNameAsync(string input)
    {
      try
      {
        var users = await GetAllProfiles();

        var resultFirst = users.Where(x => x.FirstName.ToUpper().Contains(input.ToUpper()));
        var resultLast = users.Where(x => x.LastName.ToUpper().Contains(input.ToUpper()));
        var result = new List<ProfileModel>();
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