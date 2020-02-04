using System.Collections.Generic;

namespace ConsidKompetens_Core.Models
{
  public class OfficeModel : BaseEntity
  {
    public string City { get; set; }
    public string StreetAddress { get; set; }
    public uint PostalCode { get; set; }
    public uint TelephoneNumber { get; set; }
    public List<EmployeeUserModel> EmployeeUserModels { get; set; }
  }
}