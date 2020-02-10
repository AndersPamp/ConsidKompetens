using System.Collections.Generic;

namespace ConsidKompetens_Core.Models
{
  public class Framework
  {
    public ApiModel Api { get; set; }
    public LinkModel Links { get; set; }
    public List<OfficeModel> Offices { get; set; }
    public List<CompetenceModel> Competences { get; set; }
    public List<ProjectModel> Projects { get; set; }
  }
  public class ApiModel
  {
    public string GetProfileUrl { get; set; }
    public string ReturnUrl { get; set; }
  }
}