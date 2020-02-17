using System.Collections.Generic;

namespace ConsidKompetens_Core.Models
{
  public class OfficeModel : BaseEntity
  {
    public string City { get; set; }
    public uint TelephoneNumber { get; set; }
    public List<ProfileModel> Employees { get; set; }=new List<ProfileModel>();
  }
}