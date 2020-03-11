using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ConsidKompetens_Core.Models
{
  public class ProjectModel : BaseEntity
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public int TimePeriodId { get; set; }
    public TimePeriod TimePeriod { get; set; }
    public ICollection<TechniqueModel> Techniques { get; set; }
    [JsonIgnore]
    public ICollection<ProjectProfileRole> ProjectProfileRoles { get; set; }
  }
}