using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ConsidKompetens_Services.DataServices
{
  public class ProfileDataService : IProfileDataService
  {
    private readonly DataDbContext _dataDbContext;

    public ProfileDataService(DataDbContext DataDbContext)
    {
      _dataDbContext = DataDbContext;
    }

    public async Task<List<ProfileModel>> GetAllProfilesAsync()
    {
      try
      {
        return await _dataDbContext.ProfileModels.Include(x => x.Competences)
          .Include(x => x.Projects).ToListAsync();
      }
      catch (Exception e)
      {

        throw new Exception(e.Message);
      }
    }

    public async Task<ProfileModel> GetProfileByIdAsync(int id)
    {
      try
      {
        return await _dataDbContext.ProfileModels.Include(x => x.Competences)
          .Include(x => x.Projects).FirstOrDefaultAsync(x => x.Id == id);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }

    }

    public async Task<ProfileModel> GetProfileByOwnerIdAsync(string ownerId)
    {
      if (ownerId != null)
      {
        try
        {
          return await _dataDbContext.ProfileModels.FirstOrDefaultAsync(x => x.OwnerID == ownerId);
        }
        catch (Exception e)
        {
          throw new Exception(e.Message);
        }
      }
      throw new Exception("");
    }

    public async Task<List<ProfileModel>> GetProfilesByOfficeIdsAsync(List<int> officeIds)
    {
      var result = new List<ProfileModel>();
      try
      {
        foreach (var officeId in officeIds)
        {
          var delta1 = (await _dataDbContext.ProfileModels.Include(x => x.Competences).Include(x => x.Projects)
            .Include(x => x.ProfileImage).Where(x => x.OfficeId == officeId).ToListAsync());
          foreach (var delta in delta1)
          {
            result.Add(delta);
          }
        }
        return result;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<ProfileModel> EditProfileByIdAsync(int id, ProfileModel profileModel)
    {
      try
      {
        var profile = await _dataDbContext.ProfileModels.Include(x => x.Competences)
          .Include(x => x.Projects).Include(x=>x.Links).FirstOrDefaultAsync(x => x.Id == id);

        profile.Competences = profileModel.Competences;
        profile.Experience = profileModel.Experience;
        profile.AboutMe = profileModel.AboutMe;
        profile.FirstName = profileModel.FirstName;
        profile.LastName = profileModel.LastName;
        profile.OfficeId = profileModel.OfficeId;
        profile.ProfileImage = profileModel.ProfileImage;
        profile.Projects = profileModel.Projects;
        profile.Links = profileModel.Links;
        profile.Role = profileModel.Role;
        profile.Title = profile.Title;
        profile.Modified = DateTime.UtcNow;

        _dataDbContext.ProfileModels.Update(profile);
        await _dataDbContext.SaveChangesAsync();
        return profileModel;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<ProfileModel> CreateNewProfileAsync(string id, ProfileModel profileModel)
    {
      try
      {
        var newUserModel = new ProfileModel
        {
          OwnerID = id,
          Created = DateTime.UtcNow
        };
        await _dataDbContext.ProfileModels.AddAsync(newUserModel);
        await _dataDbContext.SaveChangesAsync();

        return profileModel;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
  }
}
