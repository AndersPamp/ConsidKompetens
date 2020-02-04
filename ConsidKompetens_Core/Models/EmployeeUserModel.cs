using System;
using System.Collections.Generic;

namespace ConsidKompetens_Core.Models
{
  public class EmployeeUserModel : BaseEntity
  {
    public string OwnerID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string AboutMe { get; set; }
    public ImageModel ProfileImage { get; set; }
    public List<CompetenceModel> Competences { get; set; }
    public List<ProjectModel> Projects { get; set; }
    public ContactStatus Status { get; set; }

  }

  public enum ContactStatus
  {
    Submitted,
    Approved,
    Rejected
  }
}