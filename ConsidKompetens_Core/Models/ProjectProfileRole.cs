
using System.ComponentModel.DataAnnotations;

namespace ConsidKompetens_Core.Models
{
  public class ProjectProfileRole
  {
    [Key]
    public int ProjectModelId { get; set; }
    public ProjectModel ProjectModel { get; set; }
    [Key]
    public int ProfileModelId { get; set; }
    public ProfileModel ProfileModel { get; set; }
    [Key]
    public int RoleModelId { get; set; }
    public RoleModel RoleModel { get; set; }
  }
}