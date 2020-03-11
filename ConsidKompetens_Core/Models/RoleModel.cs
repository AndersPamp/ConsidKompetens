using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ConsidKompetens_Core.Models
{
  public class RoleModel:BaseEntity
  {
    public string Name { get; set; }
    [JsonIgnore]
    public ICollection<ProjectProfileRole> ProjectProfileRoles { get; set; }
  }
}