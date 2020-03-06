using System.Collections.Generic;

namespace ConsidKompetens_Core.Models
{
  public class RoleModel:BaseEntity
  {
    public string Name { get; set; }
    public ICollection<ProjectProfileRole> ProjectProfileRoles { get; set; }
  }
}