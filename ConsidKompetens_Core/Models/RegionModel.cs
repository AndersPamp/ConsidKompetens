using System.Collections.Generic;

namespace ConsidKompetens_Core.Models
{
  public class RegionModel : BaseEntity
  {
    public string Name { get; set; }
    public List<OfficeModel> Offices { get; set; }
  }
}