using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsidKompetens_Web.DTO
{
  public class ProjectDTO
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public int TimePeriodId { get; set; }
    public TimePeriodDTO TimePeriod { get; set; }
    public ICollection<TechniqueDTO> Techniques { get; set; }
  }
}
