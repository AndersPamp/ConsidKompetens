using System.Collections.Generic;

namespace ConsidKompetens_Core.DTO
{
  public class ProjectDto:BaseDto
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public int TimePeriodId { get; set; }
    public TimePeriodDto TimePeriod { get; set; }
    public ICollection<TechniqueDto> Techniques { get; set; }
  }
}
