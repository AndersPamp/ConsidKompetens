using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ConsidKompetens_Services.DataServices
{
  public class CompetenceDataService:ICompetenceDataService
  {
    private readonly DataDbContext _dbContext;
    private readonly ILogger<CompetenceDataService> _logger;

    public CompetenceDataService(DataDbContext dbContext, ILogger<CompetenceDataService> logger)
    {
      _dbContext = dbContext;
      _logger = logger;
    }
    public async Task<IEnumerable<CompetenceModel>> GetAllCompetencesAsync()
    {
      try
      {
        return await _dbContext.CompetenceModels.ToListAsync();
      }
      catch (Exception e)
      {
        throw new Exception(_logger + e.Message);
      }
    }

    public async Task<CompetenceModel> GetCompetenceByNameAsync(string input)
    {
      try
      {
        return await _dbContext.CompetenceModels.FirstOrDefaultAsync(x => x.Name.ToUpper().Contains(input.ToUpper()));
      }
      catch (Exception e)
      {
        throw new Exception(_logger + e.Message);
      }
    }

    public async Task<CompetenceModel> GetCompetenceByIdAsync(int id)
    {
      try
      {
        return await _dbContext.CompetenceModels.FindAsync(id);
      }
      catch (Exception e)
      {
        throw new Exception(_logger + e.Message);
      }
    }
  }
}