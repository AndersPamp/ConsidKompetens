using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ConsidKompetens_Core.DTO;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Core.Response_Request;
using ConsidKompetens_Data.Data;
using IdentityServer4.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ConsidKompetens_Services.DataServices
{
  public class SearchService : ISearchDataService
  {
    private readonly DataDbContext _dbContext;
    private readonly IMapper _mapper;

    public SearchService(DataDbContext dbContext, IMapper mapper)
    {
      _dbContext = dbContext;
      _mapper = mapper;
    }

    public async Task<List<ProfileModel>> GetAllProfilesAsync()
    {
      try
      {
        return await _dbContext.ProfileModels.Include(x => x.Competences)
          .Include(x => x.ImageModel).ToListAsync();
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
          var officeDelta = await _dbContext.OfficeModels
            .Include(x => x.ProfileModels).ThenInclude(x=>x.ImageModel)
            .Include(x=>x.ProfileModels).ThenInclude(x=>x.Competences)
            .FirstOrDefaultAsync(x => x.Id == officeId);
          result.Add(officeDelta);
        }
        return result;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
    public async Task<List<ProfileModel>> GetProfilesByCompetenceAsync(string competenceInput)
    {
      try
      {
        
        var users = await GetAllProfilesAsync();
        var result = new List<ProfileModel>();

        foreach (var user in users)
        {
          foreach (var competence in user.Competences)
          {
            if (competence.Value.ToUpper().Contains(competenceInput.ToUpper()))
            {
              result.Add(user);
            }
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
    public async Task<Response> FreeWordSearcAsync(List<int> officeIds, string input)
    {
      var response = new Response();
      var profiles = new List<ProfileModel>();
      var allOffices = await GetSelectedOfficesAsync(officeIds);
      var offices = new List<OfficeModel>();
      
      try
      {
        foreach (var office in allOffices)
        {
          foreach (var profile in office.ProfileModels)
          {
            if (profile.FirstName.ToUpper().Contains(input.ToUpper())||profile.LastName.ToUpper().Contains(input.ToUpper()))
            {
              profiles.Add(profile);
            }
            foreach (var competence in profile.Competences)
            {
              if (competence.Value.ToUpper().Contains(input.ToUpper()))
              {
                profiles.Add(profile);
              }
            }
          }
        }

        foreach (var office in allOffices)
        {
          if (office.City.ToUpper().Contains(input.ToUpper()))
          {
            offices.Add(office);
          }
        }

        response.Data.ProfileModels = _mapper.Map<List<ProfileModel>, List<ProfileDTO>>(profiles);
        response.Data.OfficeModels = _mapper.Map<List<OfficeModel>, List<OfficeDTO>>(offices);
        return response;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
  }
}
