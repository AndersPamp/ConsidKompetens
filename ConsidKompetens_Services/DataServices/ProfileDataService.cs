using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ConsidKompetens_Core.CommunicationModels;
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
    private readonly DataDbContext _dbContext;
    private readonly IOptions<AppSettings> _options;
    private readonly IImageDataService _imageDataService;
    private readonly IOfficeDataService _officeDataService;

    public ProfileDataService(IOptions<AppSettings> options, DataDbContext DataDbContext, IImageDataService imageDataService, IOfficeDataService officeDataService)
    {
      _options = options;
      _dbContext = DataDbContext;
      _imageDataService = imageDataService;
      _officeDataService = officeDataService;
    }

    public async Task<List<ProfileModel>> GetAllProfilesAsync()
    {
      try
      {
        return await _dbContext.ProfileModels.Include(x => x.ImageModel)
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
        return await _dbContext.ProfileModels.Include(x => x.Competences)
          .Include(x => x.ImageModel)
          .Include(x => x.ProjectProfileRoles).ThenInclude(x => x.ProjectModel).ThenInclude(x => x.TimePeriod)
          .Include(x => x.ProjectProfileRoles).ThenInclude(x => x.ProjectModel).ThenInclude(x => x.Techniques)
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
          return await _dbContext.ProfileModels.Include(x => x.Competences)
            .Include(x => x.ImageModel)
            .Include(x => x.ProjectProfileRoles).ThenInclude(x => x.ProjectModel).ThenInclude(x => x.TimePeriod)
            .Include(x => x.ProjectProfileRoles).ThenInclude(x => x.ProjectModel).ThenInclude(x => x.Techniques)
            .FirstOrDefaultAsync(x => x.OwnerID == profileOwnerId);
        }
        catch (Exception e)
        {
          throw new Exception(e.Message);
        }
      }
      throw new Exception("Invalid input");
    }

    public async Task<List<ProfileModel>> GetProfilesByOfficeIdsAsync(List<int> officeIds)
    {
      var offices = new List<OfficeModel>();
      var profiles = new List<ProfileModel>();
      try
      {
        foreach (var officeId in officeIds)
        {
          offices.Add(await _dbContext.OfficeModels.Include(x=>x.ProfileModels).FirstOrDefaultAsync(x=>x.Id==officeId));
        }
        foreach (var office in offices)
        {
          foreach (var profile in office.ProfileModels)
          {
            profiles.Add(profile);
          }
        }
        return profiles;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<ProfileModel> EditProfileByIdAsync(int profileId, ProfileModelReq input)
    {
      try
      {
        var profile = await _dbContext.ProfileModels.Include(x => x.Competences)
          .Include(x => x.ImageModel)
          .Include(x => x.ProjectProfileRoles).ThenInclude(x => x.ProjectModel).ThenInclude(x => x.TimePeriod)
          .Include(x => x.ProjectProfileRoles).ThenInclude(x => x.ProjectModel).ThenInclude(x => x.Techniques)
          .FirstOrDefaultAsync(x => x.Id == profileId);

        profile.Competences = input.Competences;
        profile.Experience = input.Experience;
        profile.AboutMe = input.AboutMe;
        profile.FirstName = input.FirstName;
        profile.LastName = input.LastName;
        profile.Position = input.Position;
        profile.Modified = DateTime.UtcNow;
        if (input.OfficeId!=0)
        {
          _dbContext.Entry(profile).Property("OfficeModelId").CurrentValue = input.OfficeId;
        }
        
        await _dbContext.SaveChangesAsync();

        return await _dbContext.ProfileModels
          .Include(x => x.Competences)
          .Include(x => x.ProjectProfileRoles).ThenInclude(x => x.ProjectModel)
          .FirstOrDefaultAsync(x => x.Id == profileId);
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
          ImageModel = new ImageModel { Created = DateTime.UtcNow, Alt="Profile picture" },
        };
        await _dbContext.ProfileModels.AddAsync(newUserModel);
        await _dbContext.SaveChangesAsync();

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
          if (profile.ImageModel == null)
          {
            var imageModel = new ImageModel { Created = DateTime.UtcNow, Url = filePath, Alt = "Profile image" };
            await _imageDataService.RegisterNewImageModelAsync(imageModel);
            profile.ImageModel = imageModel;
            await _dbContext.SaveChangesAsync();
          }
          else
          {
            await _imageDataService.EditImageModelAsync(profile.ImageModel.Id, new ImageModel { Modified = DateTime.UtcNow, Url = filePath, Alt = "Profile image" });
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

    public async Task<bool> DeleteProfileAsync(int profileId)
    {
      try
      {
        var profile = await _dbContext.ProfileModels.FirstOrDefaultAsync(x => x.Id == profileId);
        _dbContext.ProfileModels.Remove(profile);
        await _dbContext.SaveChangesAsync();
        return true;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
  }
}
