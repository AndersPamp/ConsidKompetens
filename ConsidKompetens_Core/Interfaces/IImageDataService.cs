using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.DTO;
using ConsidKompetens_Core.Models;

namespace ConsidKompetens_Core.Interfaces
{
  public interface IImageDataService
  {
    Task<List<ImageDto>> GetImageModelsAsync();
    Task<ImageDto> GetImageModelByIdAsync(int id);
    Task<ImageDto> RegisterNewImageModelAsync(ImageModel imageModel);
    Task<ImageDto> EditImageModelAsync(int imageId, ImageModel imageModel);
  }
}