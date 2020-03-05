using System.Collections.Generic;

namespace ConsidKompetens_Core.Models
{
  public class OfficeModel : BaseEntity
  {
    public string City { get; set; }
    public string TelephoneNumber { get; set; }
    public ICollection<ProfileModel> ProfileModels { get; set; }
  }
}