using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ConsidKompetens_Core.Models
{
  public class ProfileModel : BaseEntity
  {
    public string OwnerID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string AboutMe { get; set; }
    public string Title { get; set; }
    public int OfficeId { get; set; }
    public ImageModel ProfileImage { get; set; }
    public List<CompetenceModel> Competences { get; set; }
    public ushort Experience { get; set; }
    public LinkModel Links { get; set; }
    public List<ProjectProfileRole> ProjectProfileRoles { get; set; }
  }
}