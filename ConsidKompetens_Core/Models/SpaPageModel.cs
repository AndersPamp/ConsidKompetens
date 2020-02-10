using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConsidKompetens_Core.Models
{
  public class SpaPageModel
  {
    public string PageTitle { get; set; }
    public bool Ok { get; set; }
    public string Message { get; set; }
    public Framework Framework { get; set; }
    public List<ProfileModel> Consultants { get; set; }
    public ProjectModel Projects { get; set; }
  }
}