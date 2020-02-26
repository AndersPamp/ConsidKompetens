﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace ConsidKompetens_Core.Interfaces
{
  public interface IProfileDataService
  {
    Task<List<ProfileModel>> GetAllProfilesAsync();
    Task<ProfileModel> GetProfileByIdAsync(int profileId);
    Task<ProfileModel> GetProfileByOwnerIdAsync(string profileOwnerId);
    Task<List<ProfileModel>> GetProfilesByOfficeIdsAsync(List<int> officeIds);
    Task<ProfileModel> EditProfileByIdAsync(int profileId, ProfileModel userModel);
    Task<ProfileModel> CreateNewProfileAsync(string profileOwnerId);
    Task<bool> ImageUploadAsync(string profileOwnerId, IFormFile file);
    Task<IFormFile> GetImageAsync(int profileId);
    Task<bool> DeleteProfileAsync(int profileId);
  }
}
