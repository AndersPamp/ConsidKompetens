using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.DTO;
using ConsidKompetens_Core.Response_Request;
using Microsoft.AspNetCore.Http;

namespace ConsidKompetens_Core.Interfaces
{
  public interface IProfileDataService
  {
    Task<List<ProfileDto>> GetAllProfilesAsync();
    Task<ProfileDto> GetProfileByIdAsync(int profileId);
    Task<ProfileDto> GetProfileByOwnerIdAsync(string profileOwnerId);
    Task<List<ProfileDto>> GetProfilesByOfficeIdsAsync(List<int> officeIds);
    Task<ProfileDto> EditProfileByIdAsync(string ownerId, ProfileReq input);
    Task<ProfileDto> CreateNewProfileAsync(string profileOwnerId);
    Task<bool> ImageUploadAsync(string profileOwnerId, IFormFile file);
    Task<bool> ResumeUploadAsync(string profileOwnerId, IFormFile file);
    Task<bool> DeleteProfileAsync(int profileId);
  }
}
