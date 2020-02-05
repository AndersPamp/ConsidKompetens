using System.Collections.Generic;
using System.Reflection.Metadata;

namespace ConsidKompetens_Core.Models
{
  public class OfficeModel : BaseEntity
  {
    public string City { get; set; }
    public uint TelephoneNumber { get; set; }
    public List<EmployeeUserModel> Employees { get; set; }
  }
}