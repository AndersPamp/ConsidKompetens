using System.Collections.Generic;
using ConsidKompetens_Core.Models;

namespace ConsidKompetens_Core.CommunicationModels
{
  public class ResponseData
  {
    public List<OfficeModel> OfficeModels { get; set; }
    public List<ProfileModel> ProfileModels { get; set; }
    public List<CompetenceModel> CompetenceModels { get; set; }
    public List<ProjectModel> ProjectModels { get; set; }
    public List<string> Images { get; set; }
  }
}