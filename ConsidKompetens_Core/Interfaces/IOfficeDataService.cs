using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.DTO;
using ConsidKompetens_Core.Models;

namespace ConsidKompetens_Core.Interfaces
{
  public interface IOfficeDataService
  {
    Task<List<OfficeDto>> GetOfficesAsync();
    Task<OfficeDto> GetOfficeByIdAsync(int officeId);
    Task<List<OfficeDto>> GetOfficesByIdsAsync(List<int> officeIds);
    Task<OfficeDto> GetOfficeContainingProfileIdAsync(int profileId);
    Task<OfficeDto> GetOfficeContainingProfileOwnerIdAsync(string ownerId);
    Task<bool> CreateNewOfficeAsync(OfficeModel officeModel);
    Task<OfficeDto> EditOfficeAsync(OfficeModel officeModel);
  }
}