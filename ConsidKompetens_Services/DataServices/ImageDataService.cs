using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ConsidKompetens_Core.DTO;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Data.Data;
using Microsoft.EntityFrameworkCore;

namespace ConsidKompetens_Services.DataServices
{
  public class ImageDataService : IImageDataService
  {
    private readonly DataDbContext _dbContext;
    private readonly IMapper _mapper;

    public ImageDataService(DataDbContext dbContext, IMapper mapper)
    {
      _dbContext = dbContext;
      _mapper = mapper;
    }
    public async Task<List<ImageDTO>> GetImageModelsAsync()
    {
      try
      {
        var images = await _dbContext.ImageModels.ToListAsync();
        return _mapper.Map<List<ImageModel>, List<ImageDTO>>(images);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<ImageDTO> GetImageModelByIdAsync(int id)
    {
      try
      {
        var image = await _dbContext.ImageModels.FindAsync(id);
        return _mapper.Map<ImageModel, ImageDTO>(image);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<ImageDTO> RegisterNewImageModelAsync(ImageModel imageModel)
    {
      try
      {
        imageModel.Created = DateTime.UtcNow;

        await _dbContext.ImageModels.AddAsync(imageModel);
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<ImageModel, ImageDTO>(imageModel);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<ImageDTO> EditImageModelAsync(int imageId, ImageModel imageModel)
    {
      try
      {
        var delta = await GetImageModelByIdAsync(imageId);
        delta.Url = imageModel.Url;
        delta.Alt = imageModel.Alt;
        delta.Modified = DateTime.UtcNow;
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<ImageModel, ImageDTO>(imageModel);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
  }
}