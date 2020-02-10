using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.Models;

namespace ConsidKompetens_Core.Interfaces
{
  public interface ISearchService
  {
    Task<List<OfficeModel>> GetSelectedOfficesAsync(List<int> selectedOffices);
    Task<List<ProfileModel>> GetProfilesByCompetenceAsync(int competenceId);
    Task<List<ProfileModel>> GetProfilesByNameAsync(string input);
  }
}