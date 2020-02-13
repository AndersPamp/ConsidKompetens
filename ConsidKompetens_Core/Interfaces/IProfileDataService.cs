using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.Models;

namespace ConsidKompetens_Core.Interfaces
{
  public interface IProfileDataService
  {
    Task<IEnumerable<ProfileModel>> GetAllProfilesAsync();
    Task<ProfileModel> GetProfileByIdAsync(int id);
    Task<ProfileModel> GetProfileByOwnerIdAsync(string ownerId);
    Task<List<ProfileModel>> GetProfilesByOfficeIdsAsync(List<int> officeIds);
    Task<ProfileModel> EditProfileByIdAsync(int id, ProfileModel userModel);
    Task<ProfileModel> CreateNewProfileAsync(string ownerId, ProfileModel profileModel);
  }
}
