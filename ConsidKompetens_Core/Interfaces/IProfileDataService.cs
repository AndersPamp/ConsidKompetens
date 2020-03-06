using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.CommunicationModels;
using ConsidKompetens_Core.Models;
using Microsoft.AspNetCore.Http;

namespace ConsidKompetens_Core.Interfaces
{
  public interface IProfileDataService
  {
    Task<List<ProfileModel>> GetAllProfilesAsync();
    Task<ProfileModel> GetProfileByIdAsync(int profileId);
    Task<ProfileModel> GetProfileByOwnerIdAsync(string profileOwnerId);
    Task<List<ProfileModel>> GetProfilesByOfficeIdsAsync(List<int> officeIds);
    Task<ProfileModel> EditProfileByIdAsync(int profileId, ProfileModelReq input);
    Task<ProfileModel> CreateNewProfileAsync(string profileOwnerId);
    Task<bool> ImageUploadAsync(string profileOwnerId, IFormFile file);
    Task<bool> DeleteProfileAsync(int profileId);
  }
}
