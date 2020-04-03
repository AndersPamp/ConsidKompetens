using System.Collections.Generic;
using ConsidKompetens_Core.DTO;

namespace ConsidKompetens_Core.Response_Request
{
  public class ResponseData
  {
    public List<OfficeDto> OfficeModels { get; set; }
    public List<ProfileDto> ProfileModels { get; set; }
    public List<ProjectDto> ProjectModels { get; set; }
    public List<string> Images { get; set; }
    public string Email { get; set; }
  }
}