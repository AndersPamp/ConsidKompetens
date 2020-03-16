using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ConsidKompetens_Core.DTO;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Core.Response_Request;
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
    private readonly IMapper _mapper;

    public ProfileDataService(IOptions<AppSettings> options, DataDbContext DataDbContext, IImageDataService imageDataService, IMapper mapper)
    {
      _options = options;
      _dbContext = DataDbContext;
      _imageDataService = imageDataService;
      _mapper = mapper;
    }

    public async Task<List<ProfileDTO>> GetAllProfilesAsync()
    {
      try
      {
        var profiles = await _dbContext.ProfileModels.Include(x => x.ImageModel)
          .Include(x => x.Competences).ToListAsync();
        return _mapper.Map<List<ProfileModel>, List<ProfileDTO>>(profiles);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<ProfileDTO> GetProfileByIdAsync(int profileId)
    {
      try
      {
        var profile = await _dbContext.ProfileModels
          .Include(x => x.Competences)
          .Include(x => x.ImageModel)
          .Include(x => x.ProjectProfileRoles)
            .ThenInclude(x => x.ProjectModel)
            .ThenInclude(x => x.TimePeriod)
          .Include(x => x.ProjectProfileRoles)
            .ThenInclude(x => x.ProjectModel)
            .ThenInclude(x => x.Techniques)
          .FirstOrDefaultAsync(x => x.Id == profileId);
        return _mapper.Map<ProfileModel, ProfileDTO>(profile);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<ProfileDTO> GetProfileByOwnerIdAsync(string profileOwnerId)
    {
      if (profileOwnerId != null)
      {
        try
        {
          var profile = await _dbContext.ProfileModels.Include(x => x.Competences)
            .Include(x => x.ImageModel)
            .Include(x => x.ProjectProfileRoles).ThenInclude(x => x.ProjectModel).ThenInclude(x => x.TimePeriod)
            .Include(x => x.ProjectProfileRoles).ThenInclude(x => x.ProjectModel).ThenInclude(x => x.Techniques)
            .FirstOrDefaultAsync(x => x.OwnerID == profileOwnerId);

          return _mapper.Map<ProfileModel, ProfileDTO>(profile);
        }
        catch (Exception e)
        {
          throw new Exception(e.Message);
        }
      }
      throw new Exception("Invalid input");
    }

    public async Task<List<ProfileDTO>> GetProfilesByOfficeIdsAsync(List<int> officeIds)
    {
      var offices = new List<OfficeModel>();
      var profiles = new List<ProfileModel>();
      try
      {
        foreach (var officeId in officeIds)
        {
          offices.Add(await _dbContext.OfficeModels.Include(x => x.ProfileModels).FirstOrDefaultAsync(x => x.Id == officeId));
        }
        foreach (var office in offices)
        {
          foreach (var profile in office.ProfileModels)
          {
            profiles.Add(profile);
          }
        }
        return _mapper.Map<List<ProfileModel>, List<ProfileDTO>>(profiles);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<ProfileDTO> EditProfileByIdAsync(string ownerId, ProfileReq input)
    {
      try
      {
        var profile = await _dbContext.ProfileModels.Include(x => x.Competences)
          .Include(x => x.ImageModel)
          .Include(x => x.ProjectProfileRoles).ThenInclude(x => x.ProjectModel).ThenInclude(x => x.TimePeriod)
          .Include(x => x.ProjectProfileRoles).ThenInclude(x => x.ProjectModel).ThenInclude(x => x.Techniques)
          .FirstOrDefaultAsync(x => x.OwnerID == ownerId);

        //var competences = input.Competences.Where(x => !profile.Competences.ToList().Exists(i => i.Id == x.Id));

        //foreach (var c in competences)
        //{
        //  profile.Competences.Add(c);
        //}
        profile.Competences = input.Competences;
        profile.AboutMe = input.AboutMe;
        profile.FirstName = input.FirstName;
        profile.LastName = input.LastName;
        profile.Position = input.Position;
        profile.LinkedInUrl = input.LinkedInUrl;
        profile.ResumeUrl = input.ResumeUrl;
        profile.OfficeModelId = input.OfficeId;

        profile.Modified = DateTime.UtcNow;

        //if (input.OfficeId != 0)
        //{
        //  _dbContext.Entry(profile).Property("OfficeModelId").CurrentValue = input.OfficeId;
        //}

        _dbContext.Update(profile);

        await _dbContext.SaveChangesAsync();

        return _mapper.Map<ProfileModel, ProfileDTO>(profile);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<ProfileDTO> CreateNewProfileAsync(string profileOwnerId)
    {
      try
      {
        var newUserModel = new ProfileModel
        {
          OwnerID = profileOwnerId,
          Created = DateTime.UtcNow,
          ImageModel = new ImageModel { Created = DateTime.UtcNow, Alt = "Profile picture" },
        };
        await _dbContext.ProfileModels.AddAsync(newUserModel);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<ProfileModel, ProfileDTO>(newUserModel);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<bool> ImageUploadAsync(string profileOwnerId, IFormFile file)
    {
      var profile = await _dbContext.ProfileModels.FirstOrDefaultAsync(x => x.OwnerID == profileOwnerId);

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

    public async Task<bool> ResumeUploadAsync(string profileOwnerId, IFormFile file)
    {
      var profile = await GetProfileByOwnerIdAsync(profileOwnerId);
      if (file.Length <= int.Parse(_options.Value.MaxResumeFileSize))
      {
        if (_options.Value.AllowedResumeFileExtensions.Contains(file.ContentType.Split('/')[1]))
        {
          var filePath = Path.Combine(_options.Value.ResumeFilePath, $"{ profileOwnerId}.{file.ContentType.Split('/')[1]}");
          profile.ResumeUrl = filePath;
          await _dbContext.SaveChangesAsync();
          await using (var stream = System.IO.File.Create(filePath))
          {
            await file.CopyToAsync(stream);
          }
          return true;
        }
        throw new Exception("The file you tried to upload is not of a supported type.");
      }
      throw new Exception("The file you tried to upload is too big.");
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
