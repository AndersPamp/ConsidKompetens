using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.DTO;
using ConsidKompetens_Core.Models;

namespace ConsidKompetens_Core.Interfaces
{
  public interface IImageDataService
  {
    Task<List<ImageDTO>> GetImageModelsAsync();
    Task<ImageDTO> GetImageModelByIdAsync(int id);
    Task<ImageDTO> RegisterNewImageModelAsync(ImageModel imageModel);
    Task<ImageDTO> EditImageModelAsync(int imageId, ImageModel imageModel);
  }
}