﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsidKompetens_Core.Models
{
  public class ProfileModel : BaseEntity
  {
    public string OwnerID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string AboutMe { get; set; }
    public string Position { get; set; }
    public int ImageModelId { get; set; }
    public ImageModel ImageModel { get; set; }
    public List<CompetenceModel> Competences { get; set; }
    public ushort Experience { get; set; }
    public string LinkedInUrl { get; set; }
    public string ResumeUrl { get; set; }
    public ICollection<ProjectProfileRole> ProjectProfileRoles { get; set; }
  }
}