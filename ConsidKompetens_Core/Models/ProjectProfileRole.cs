namespace ConsidKompetens_Core.Models
{
  public class ProjectProfileRole
  {
    public int ProjectId { get; set; }
    public ProjectModel ProjectModel { get; set; }
    public int ProfileId { get; set; }
    public ProfileModel ProfileModel { get; set; }
    public int RoleId { get; set; }
    public RoleModel RoleModel { get; set; }
  }
}