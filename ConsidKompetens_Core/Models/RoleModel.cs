using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ConsidKompetens_Core.Models
{
  public class RoleModel:BaseEntity
  {
    public string Name { get; set; }
    public List<ProjectProfileRole> ProjectProfileRoles { get; set; }
  }
}