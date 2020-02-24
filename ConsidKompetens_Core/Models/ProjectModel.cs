﻿using System.Collections.Generic;

namespace ConsidKompetens_Core.Models
{
  public class ProjectModel : BaseEntity
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<RoleModel> Roles { get; set; }
    public List<TechniqueModel> Techniques { get; set; }
    public TimePeriod TimePeriod { get; set; }
    public List<ProfileModel> ProfileModels { get; set; }
  }
}