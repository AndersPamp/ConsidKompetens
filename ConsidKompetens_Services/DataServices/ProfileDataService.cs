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
    private readonly IImageDataService _imageDataService;

    public ProfileDataService(IOptions<AppSettings> options, DataDbContext DataDbContext, IImageDataService imageDataService)
    {
      _options = options;
      _dataDbContext = DataDbContext;
      _imageDataService = imageDataService;
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

    public async Task<ProfileModel> GetProfileByIdAsync(int profileId)
    {
      try
      {
        return await _dataDbContext.ProfileModels.Include(x => x.Competences)
          .Include(x => x.ProfileImage)
          .Include(x => x.Links)
          .Include(x=>x.ProjectProfileRoles).ThenInclude(x=>x.ProjectModel).ThenInclude(x=>x.TimePeriod)
          .Include(x=>x.ProjectProfileRoles).ThenInclude(x=>x.ProjectModel).ThenInclude(x=>x.Techniques)
          .FirstOrDefaultAsync(x => x.Id == profileId);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<ProfileModel> GetProfileByOwnerIdAsync(string profileOwnerId)
    {
      if (profileOwnerId != null)
      {
        try
        {
          return await _dataDbContext.ProfileModels.Include(x => x.Competences)
            .Include(x => x.ProfileImage)
            .Include(x => x.Links)
            // .Include(x=>x.ProjectProfileRoles).ThenInclude(x=>x.ProjectModel).ThenInclude(x=>x.TimePeriod)
            // .Include(x=>x.ProjectProfileRoles).ThenInclude(x=>x.ProjectModel).ThenInclude(x=>x.Techniques)
            .FirstOrDefaultAsync(x => x.OwnerID == profileOwnerId);
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

    public async Task<ProfileModel> EditProfileByIdAsync(int profileId, ProfileModel profileModel)
    {
      try
      {
        var profile = await _dataDbContext.ProfileModels.Include(x => x.Competences)
          .Include(x => x.ProfileImage)
          .Include(x => x.Links)
          // .Include(x=>x.ProjectProfileRoles).ThenInclude(x=>x.ProjectModel).ThenInclude(x=>x.TimePeriod)
          // .Include(x=>x.ProjectProfileRoles).ThenInclude(x=>x.ProjectModel).ThenInclude(x=>x.Techniques)
          .FirstOrDefaultAsync(x => x.Id == profileId);

        profile.Competences = profileModel.Competences;
        profile.Experience = profileModel.Experience;
        profile.AboutMe = profileModel.AboutMe;
        profile.FirstName = profileModel.FirstName;
        profile.LastName = profileModel.LastName;
        profile.OfficeId = profileModel.OfficeId;
        profile.Links = profileModel.Links;
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

    public async Task<ProfileModel> CreateNewProfileAsync(string profileOwnerId)
    {
      try
      {
        var newUserModel = new ProfileModel
        {
          OwnerID = profileOwnerId,
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

    public async Task<bool> ImageUploadAsync(string profileOwnerId, IFormFile file)
    {
      var profile = await GetProfileByOwnerIdAsync(profileOwnerId);

      if (file.Length <= int.Parse(_options.Value.MaxFileSize))
      {
        if (_options.Value.AllowedFileExtensions.Contains(file.ContentType.Split('/')[1]))
        {
          var filePath = Path.Combine(_options.Value.ImageFilePath, $"{profileOwnerId}.{file.ContentType.Split('/')[1]}");
          if (profile.ProfileImage == null)
          {
            var imageModel = new ImageModel { Created = DateTime.UtcNow, Url = filePath, Alt = "Profile image" };
            await _imageDataService.RegisterNewImageModelAsync(imageModel);
            profile.ProfileImage = imageModel;
            await _dataDbContext.SaveChangesAsync();
          }
          else
          {
            await _imageDataService.EditImageModelAsync(profile.ProfileImage.Id, new ImageModel { Modified = DateTime.UtcNow, Url = filePath, Alt = "Profile image" });
          }

          await using (var stream = System.IO.File.Create(filePath))
          {
            await file.CopyToAsync(stream);
          }
          return true;
        }
      }
      throw new Exception(ImageUploadAsync(profileOwnerId, file).Result.ToString());
    }

    // public async Task<IFormFile> GetImageAsync(int profileId)
    // {
    //   var filePath = (await _dataDbContext.ProfileModels.FirstOrDefaultAsync(x => x.Id == profileId)).ProfileImage.Url;
    //   await using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
    //   {
    //     //await stream.ReadAsync()
    //   }
    //
    //   return null;
    // }

    public async Task<bool> DeleteProfileAsync(int profileId)
    {
      try
      {
        var profile = await _dataDbContext.ProfileModels.FirstOrDefaultAsync(x => x.Id == profileId);
        _dataDbContext.ProfileModels.Remove(profile);
        await _dataDbContext.SaveChangesAsync();
        return true;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
  }
}
