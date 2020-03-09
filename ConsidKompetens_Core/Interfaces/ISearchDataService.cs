using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.CommunicationModels;
using ConsidKompetens_Core.Models;

namespace ConsidKompetens_Core.Interfaces
{
  public interface ISearchDataService
  {
    Task<List<OfficeModel>> GetSelectedOfficesAsync(List<int> selectedOffices);
    Task<List<ProfileModel>> GetProfilesByCompetenceAsync(string competenceInput);
    Task<ResponseModel> FreeWordSearcAsync(List<int> officeIds, string input);

  }
}
