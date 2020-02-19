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
    private readonly DataDbContext _dbContext;

    public SearchService(DataDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<List<ProfileModel>> GetAllProfilesAsync()
    {
      try
      {
        return await _dbContext.ProfileModels.Include(x => x.Competences)
          .Include(x => x.ProfileImage).ToListAsync();
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
        return await _dbContext.OfficeModels.ToListAsync();
      }
      try
      {

        foreach (var officeId in selectedOfficeIds)
        {
          var officeDelta = await _dbContext.OfficeModels.Include(x => x.Employees).FirstOrDefaultAsync(x => x.Id == officeId);
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
        var competence = await _dbContext.CompetenceModels.FirstOrDefaultAsync(x => x.Id == competenceId);
        var users = await GetAllProfilesAsync();
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
    //search first name, last name & competences
    public async Task<SpaPageModel> FreeWordSearcAsync(string input)
    {
      var spa = new SpaPageModel();
      var allProfiles = await GetAllProfilesAsync();
      var profiles = new List<ProfileModel>();
      var allOffices = await _dbContext.OfficeModels.ToListAsync();
      var offices = new List<OfficeModel>();
      try
      {
        foreach (var profile in allProfiles)
        {
          foreach (var competence in profile.Competences)
          {
            if (competence.Name.ToUpper().Contains(input.ToUpper()))
            {
              profiles.Add(profile);
            }
          }
        }

        var resultFirst = allProfiles.Where(x => x.FirstName.ToUpper().Contains(input.ToUpper()));
        var resultLast = allProfiles.Where(x => x.LastName.ToUpper().Contains(input.ToUpper()));

        foreach (var first in resultFirst)
        {
          profiles.Add(first);
        }
        foreach (var last in resultLast)
        {
          profiles.Add(last);
        }
        foreach (var office in allOffices)
        {
          if (office.City.ToUpper().Contains(input.ToUpper()))
          {
            offices.Add(office);
          }
        }

        spa.Consultants = profiles;
        spa.Framework.Offices = offices;
        return spa;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
  }
}
