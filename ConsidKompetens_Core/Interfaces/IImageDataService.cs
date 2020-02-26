using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.Models;

namespace ConsidKompetens_Core.Interfaces
{
  public interface IImageDataService
  {
    Task<List<ImageModel>> GetImageModelsAsync();
    Task<ImageModel> GetImageModelByIdAsync(int id);
    Task<ImageModel> RegisterNewImageModelAsync(ImageModel imageModel);
    Task<ImageModel> EditImageModelAsync(int imageId, ImageModel imageModel);
  }
}