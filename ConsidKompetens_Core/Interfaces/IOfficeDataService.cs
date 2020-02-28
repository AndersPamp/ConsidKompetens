using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.Models;

namespace ConsidKompetens_Core.Interfaces
{
  public interface IOfficeDataService
  {
    Task<List<OfficeModel>> GetOfficesAsync();
    Task<OfficeModel> GetOfficeByIdAsync(int officeId);
    Task<List<OfficeModel>> GetOfficesByIdsAsync(List<int> officeIds);
    Task<bool> CreateNewOfficeAsync(OfficeModel officeModel);
    Task<OfficeModel> EditOfficeAsync(OfficeModel officeModel);
  }
}