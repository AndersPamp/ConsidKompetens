using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ConsidKompetens_Core.DTO;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Data.Data;
using Microsoft.EntityFrameworkCore;

namespace ConsidKompetens_Services.DataServices
{
  public class OfficeDataService : IOfficeDataService
  {
    private readonly DataDbContext _dbContext;
    private readonly IMapper _mapper;

    public OfficeDataService(DataDbContext dbContext, IMapper mapper)
    {
      _dbContext = dbContext;
      _mapper = mapper;
    }

    public async Task<List<OfficeDto>> GetOfficesAsync()
    {
      try
      {
        var offices = await _dbContext.OfficeModels.Include(x => x.ProfileModels).ThenInclude(x => x.Competences)
          .Include(x => x.ProfileModels).ThenInclude(x => x.ImageModel)
          .Include(x => x.ProfileModels).ThenInclude(x => x.Competences)
          .Include(x => x.ProfileModels).ThenInclude(x => x.ProjectProfileRoles).ThenInclude(x => x.ProjectModel).ThenInclude(x => x.Techniques).ToListAsync();
        return _mapper.Map<List<OfficeModel>, List<OfficeDto>>(offices);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<OfficeDto> GetOfficeByIdAsync(int officeId)
    {
      try
      {
        var office = await _dbContext.OfficeModels.Include(x => x.ProfileModels).ThenInclude(x => x.Competences)
          .Include(x => x.ProfileModels).ThenInclude(x => x.Competences)
          .FirstOrDefaultAsync(x => x.Id == officeId);
        return _mapper.Map<OfficeModel, OfficeDto>(office);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<List<OfficeDto>> GetOfficesByIdsAsync(List<int> officeIds)
    {
      var result = new List<OfficeModel>();
      try
      {
        foreach (var officeId in officeIds)
        {
          var office = await _dbContext.OfficeModels.Include(x => x.ProfileModels).ThenInclude(x => x.Competences)
            .Include(x => x.ProfileModels).ThenInclude(x => x.Competences)
            .Include(x => x.ProfileModels).ThenInclude(x => x.ProjectProfileRoles).ThenInclude(x => x.ProjectModel).ThenInclude(x => x.Techniques)
            .FirstOrDefaultAsync(x => x.Id == officeId);

          result.Add(office);
        }
        return _mapper.Map<List<OfficeModel>, List<OfficeDto>>(result);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<OfficeDto> GetOfficeContainingProfileOwnerIdAsync(string ownerId)
    {
      try
      {
        var officeResult = new OfficeModel();
        var offices = await _dbContext.OfficeModels.Include(x => x.ProfileModels).ToListAsync();
        foreach (var office in offices)
        {
          foreach (var profile in office.ProfileModels)
          {
            if (profile.OwnerID == ownerId)
            {
              officeResult = office;
            }
          }
        }

        return _mapper.Map<OfficeModel, OfficeDto>(officeResult);
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
        officeModel.Created = DateTime.UtcNow;
        await _dbContext.OfficeModels.AddAsync(officeModel);
        return true;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<OfficeDto> EditOfficeAsync(OfficeModel officeModel)
    {
      try
      {
        var model = await _dbContext.OfficeModels.FindAsync(officeModel.Id);
        model.City = officeModel.City;
        model.ProfileModels = officeModel.ProfileModels;
        model.TelephoneNumber = officeModel.TelephoneNumber;
        model.Modified = DateTime.Now;
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<OfficeModel, OfficeDto>(model);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<OfficeDto> GetOfficeContainingProfileIdAsync(int profileId)
    {
      try
      {
        var officeResult = new OfficeModel();
        var offices = await _dbContext.OfficeModels.Include(x => x.ProfileModels).ToListAsync();
        foreach (var office in offices)
        {
          foreach (var profile in office.ProfileModels)
          {
            if (profile.Id == profileId)
            {
              officeResult = office;
            }
          }
        }
        return _mapper.Map<OfficeModel, OfficeDto>(officeResult);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
  }
}
