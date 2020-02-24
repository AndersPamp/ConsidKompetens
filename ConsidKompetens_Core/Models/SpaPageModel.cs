using System.Collections.Generic;

namespace ConsidKompetens_Core.Models
{
  public class ResponseModel
  {
    public string PageTitle { get; set; }
    public bool Ok { get; set; }
    public string BearerToken { get; set; }
    public string Message { get; set; }
    public Framework Framework { get; set; }
    public List<ProfileModel> Consultants { get; set; }
    public List<ProjectModel> Projects { get; set; }
  }
}