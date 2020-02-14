using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Data.Data;
using Microsoft.Extensions.Logging;

namespace ConsidKompetens_Services.DataServices
{
  public class OfficeDataService : IOfficeDataService
  {
    private readonly DataDbContext _dbContext;

    public OfficeDataService(DataDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<IEnumerable<OfficeModel>> GetOfficesByIdsAsync(List<int> officeIds)
    {
      var result = new List<OfficeModel>();
      try
      {
        foreach (var officeId in officeIds)
        {
          result.Add(await _dbContext.OfficeModels.FindAsync(officeId));
        }
        return result;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<bool> CreateNewOfficeAsync(OfficeModel officeModel)
    {
      try
      {
        await _dbContext.OfficeModels.AddAsync(officeModel);
        return true;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<OfficeModel> EditOfficeAsync(OfficeModel officeModel)
    {
      try
      {
        var model = await _dbContext.OfficeModels.FindAsync(officeModel.Id);
        model.City = officeModel.City;
        model.Employees = officeModel.Employees;
        model.TelephoneNumber = officeModel.TelephoneNumber;
        model.Modified = DateTime.Now;
        _dbContext.OfficeModels.Update(model);
        return model;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
  }
}