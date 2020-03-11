using System.Collections.Generic;
using ConsidKompetens_Core.DTO;

namespace ConsidKompetens_Core.Response_Request
{
  public class ResponseData
  {
    public List<OfficeDTO> OfficeModels { get; set; }
    public List<ProfileDTO> ProfileModels { get; set; }
    public List<ProjectDTO> ProjectModels { get; set; }
    public List<CompetenceDTO> CompetenceModels { get; set; }
    public List<string> Images { get; set; }
    public string Email { get; set; }
  }
}