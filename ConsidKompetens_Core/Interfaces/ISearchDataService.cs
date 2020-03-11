using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Core.Response_Request;

namespace ConsidKompetens_Core.Interfaces
{
  public interface ISearchDataService
  {
    Task<List<OfficeModel>> GetSelectedOfficesAsync(List<int> selectedOffices);
    Task<List<ProfileModel>> GetProfilesByCompetenceAsync(string competenceInput);
    Task<Response> FreeWordSearcAsync(List<int> officeIds, string input);

  }
}
