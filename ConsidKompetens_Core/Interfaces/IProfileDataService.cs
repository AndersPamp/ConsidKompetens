using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.DTO;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Core.Response_Request;
using Microsoft.AspNetCore.Http;

namespace ConsidKompetens_Core.Interfaces
{
  public interface IProfileDataService
  {
    Task<List<ProfileDTO>> GetAllProfilesAsync();
    Task<ProfileDTO> GetProfileByIdAsync(int profileId);
    Task<ProfileDTO> GetProfileByOwnerIdAsync(string profileOwnerId);
    Task<List<ProfileDTO>> GetProfilesByOfficeIdsAsync(List<int> officeIds);
    Task<ProfileDTO> EditProfileByIdAsync(int profileId, ProfileReq input);
    Task<ProfileDTO> CreateNewProfileAsync(string profileOwnerId);
    Task<bool> ImageUploadAsync(string profileOwnerId, IFormFile file);
    Task<bool> ResumeUploadAsync(string profileOwnerId, IFormFile file);
    Task<bool> DeleteProfileAsync(int profileId);
  }
}
