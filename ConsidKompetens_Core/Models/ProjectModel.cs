namespace ConsidKompetens_Core.Models
{
  public class ProjectModel : BaseEntity
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public Role Role { get; set; }
    public Techniques Techniques { get; set; }
    public string TimePeriod { get; set; }
  }

  public enum Techniques
  {
  }
}