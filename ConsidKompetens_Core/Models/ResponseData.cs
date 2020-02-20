using System.Collections.Generic;

namespace ConsidKompetens_Core.Models
{
  public class ResponseData
  {
    public List<OfficeModel> OfficeModels { get; set; }
    public List<ProfileModel> ProfileModels { get; set; }
    public List<CompetenceModel> CompetenceModels { get; set; }
    public List<ProjectModel> ProjectModels { get; set; }
  }
}