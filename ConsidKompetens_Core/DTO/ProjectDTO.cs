using System.Collections.Generic;

namespace ConsidKompetens_Core.DTO
{
  public class ProjectDTO:BaseDTO
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public int TimePeriodId { get; set; }
    public TimePeriodDTO TimePeriod { get; set; }
    public ICollection<TechniqueDTO> Techniques { get; set; }
  }
}
