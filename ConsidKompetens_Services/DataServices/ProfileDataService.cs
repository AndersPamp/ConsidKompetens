using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Data.Data;
using Microsoft.EntityFrameworkCore;

namespace ConsidKompetens_Services.DataServices
{
  public class ProfileDataService : IProfileDataService
  {
    private readonly ProfileDataContext _profileDataContext;

    public ProfileDataService(ProfileDataContext profileDataContext)
    {
      _profileDataContext = profileDataContext;
    }

    public async Task<List<ProfileModel>> GetAllProfilesAsync()
    {
      try
      {
        return await _profileDataContext.ProfileModels.Include(x => x.Competences)
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
        return await _profileDataContext.ProfileModels.Include(x => x.Competences)
          .Include(x => x.Projects).FirstOrDefaultAsync(x => x.Id == id);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }

    }

    public async Task<ProfileModel> GetProfileByOwnerIdAsync(string ownerId)
    {
      if (ownerId!=null)
      {
        try
        {
          return await _profileDataContext.ProfileModels.FirstOrDefaultAsync(x => x.OwnerID == ownerId);
        }
        catch (Exception e)
        {
          throw new Exception(e.Message);
        }
      }
      throw new Exception(message:"No such profile could be found");
    }

    public async Task<ProfileModel> EditProfileByIdAsync(int id, ProfileModel userModel)
    {
      try
      {
        var user = await _profileDataContext.ProfileModels.Include(x => x.Competences)
          .Include(x => x.Projects).FirstOrDefaultAsync(x => x.Id == id);
        user.AboutMe = userModel.AboutMe;
        user.ProfileImage = userModel.ProfileImage;
        _profileDataContext.ProfileModels.Update(user);
        await _profileDataContext.SaveChangesAsync();
        return userModel;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<ProfileModel> CreateNewProfileAsync(ProfileModel userModel)
    {
      try
      {
        var newUserModel = new ProfileModel()
        {
          AboutMe = userModel.AboutMe,
          ProfileImage = userModel.ProfileImage,
          Competences = userModel.Competences
        };
        await _profileDataContext.ProfileModels.AddAsync(newUserModel);
        await _profileDataContext.SaveChangesAsync();

        return userModel;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
  }
}
