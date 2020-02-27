namespace ConsidKompetens_Core.Models
{
  public class ProjectProfileRole
  {
    public int ProjectId { get; set; }
    public ProjectModel Project { get; set; }
    public int ProfileId { get; set; }
    public ProfileModel Profile { get; set; }
    public int RoleId { get; set; }
    public RoleModel Role { get; set; }
  }
}