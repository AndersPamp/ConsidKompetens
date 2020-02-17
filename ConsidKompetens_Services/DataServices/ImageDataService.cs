using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Data.Data;
using Microsoft.EntityFrameworkCore;

namespace ConsidKompetens_Services.DataServices
{
  public class ImageDataService : IImageDataService
  {
    private readonly DataDbContext _dbContext;

    public ImageDataService(DataDbContext dbContext)
    {
      _dbContext = dbContext;
    }
    public async Task<List<ImageModel>> GetImageModelsAsync()
    {
      try
      {
        return await _dbContext.ImageModels.ToListAsync();
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<ImageModel> GetImageModelByIdAsync(int id)
    {
      try
      {
        return await _dbContext.ImageModels.FirstOrDefaultAsync(x => x.Id == id);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<ImageModel> RegisterNewImageModelAsync(ImageModel imageModel)
    {
      try
      {
        imageModel.Created = DateTime.UtcNow;

        await _dbContext.ImageModels.AddAsync(imageModel);
        await _dbContext.SaveChangesAsync();
        return imageModel;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<ImageModel> EditImageModelAsync(ImageModel imageModel)
    {
      try
      {
        var delta = await GetImageModelByIdAsync(imageModel.Id);
        delta.Url = imageModel.Url;
        delta.Alt = imageModel.Alt;
        delta.Modified = DateTime.UtcNow;
        await _dbContext.SaveChangesAsync();
        return imageModel;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
  }
}