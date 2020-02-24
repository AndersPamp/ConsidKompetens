using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Data.Data;
using ConsidKompetens_Services.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ConsidKompetens_Services.DataServices
{
  public class ProfileDataService : IProfileDataService
  {
    private readonly DataDbContext _dataDbContext;
    private readonly IOptions<AppSettings> _options;

    public ProfileDataService(IOptions<AppSettings> options, DataDbContext DataDbContext)
    {
      _options = options;
      _dataDbContext = DataDbContext;
    }

    public async Task<List<ProfileModel>> GetAllProfilesAsync()
    {
      try
      {
        return await _dataDbContext.ProfileModels.Include(x => x.ProfileImage)
          .Include(x => x.Competences).ToListAsync();
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
          .FirstOrDefaultAsync(x => x.Id == id);
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
          var delta1 = (await _dataDbContext.ProfileModels.Include(x => x.Competences)
            .Include(x => x.ProfileImage).Include(x => x.Links)
            .Where(x => x.OfficeId == officeId).ToListAsync());

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
          .Include(x => x.ProfileImage).Include(x => x.Links)
          .FirstOrDefaultAsync(x => x.Id == id);

        profile.Competences = profileModel.Competences;
        profile.Experience = profileModel.Experience;
        profile.AboutMe = profileModel.AboutMe;
        profile.FirstName = profileModel.FirstName;
        profile.LastName = profileModel.LastName;
        profile.OfficeId = profileModel.OfficeId;
        profile.ProfileImage = profileModel.ProfileImage;
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

    public async Task<ProfileModel> CreateNewProfileAsync(string ownerId)
    {
      try
      {
        var newUserModel = new ProfileModel
        {
          OwnerID = ownerId,
          Created = DateTime.UtcNow,
          ProfileImage = new ImageModel { Created = DateTime.UtcNow },
        };
        await _dataDbContext.ProfileModels.AddAsync(newUserModel);
        await _dataDbContext.SaveChangesAsync();

        return newUserModel;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
    
    public async Task<bool> ImageUploadAsync(IFormFile file)
    {
      {
        if (file.Length > 0)
        {
          var filePath = Path.Combine(_options.Value.ImageFilePath,
            Path.GetRandomFileName());

          using (var stream = System.IO.File.Create(filePath))
          {
            await file.CopyToAsync(stream);
          }
        }
      }
      return true;
    }
  }
}
