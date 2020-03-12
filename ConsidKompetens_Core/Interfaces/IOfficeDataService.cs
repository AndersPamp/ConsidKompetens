using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.DTO;
using ConsidKompetens_Core.Models;

namespace ConsidKompetens_Core.Interfaces
{
  public interface IOfficeDataService
  {
    Task<List<OfficeDTO>> GetOfficesAsync();
    Task<OfficeDTO> GetOfficeByIdAsync(int officeId);
    Task<List<OfficeDTO>> GetOfficesByIdsAsync(List<int> officeIds);
    Task<OfficeDTO> GetOfficeContainingProfileIdAsync(int profileId);
    Task<OfficeDTO> GetOfficeContainingProfileOwnerIdAsync(string ownerId);
    Task<bool> CreateNewOfficeAsync(OfficeModel officeModel);
    Task<OfficeDTO> EditOfficeAsync(OfficeModel officeModel);
  }
}