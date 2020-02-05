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
    public Role Role { get; set; }
    public string Title { get; set; }
    public int OfficeId { get; set; }
    public ImageModel ProfileImage { get; set; }
    public List<int> CompetenceIds { get; set; }
    public List<int> ProjectIds { get; set; }
    public ushort Experience { get; set; }
  }

  public enum Role
  {
    Developer,
    ProjectLeader
  }
}