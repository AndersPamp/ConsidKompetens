namespace ConsidKompetens_Core.Models
{
  public class CompetenceModel : BaseEntity
  {
    public int ProfileModelId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Level Level { get; set; }
  }

  public enum Level
  {
    Good,
    Intermediate,
    Moderate
  }
}
