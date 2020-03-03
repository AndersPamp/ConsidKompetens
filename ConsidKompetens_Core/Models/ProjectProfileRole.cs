
using System.ComponentModel.DataAnnotations;

namespace ConsidKompetens_Core.Models
{
  public class ProjectProfileRole
  {
    public int ProjectModelId { get; set; }
    public ProjectModel ProjectModel { get; set; }
    public int ProfileModelId { get; set; }
    public ProfileModel ProfileModel { get; set; }
    public int RoleModelId { get; set; }
    public RoleModel RoleModel { get; set; }
  }
}