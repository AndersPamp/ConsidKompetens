using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.Models;

namespace ConsidKompetens_Core.Interfaces
{
  public interface ICompetenceDataService
  {
    Task<IEnumerable<CompetenceModel>> GetAllCompetencesAsync();
    Task<CompetenceModel> GetCompetenceByNameAsync(string input);
    Task<CompetenceModel> GetCompetenceByIdAsync(int id);
    Task<CompetenceModel> RegisterNewCompetenceAsync(CompetenceModel competenceModel);
  }
}