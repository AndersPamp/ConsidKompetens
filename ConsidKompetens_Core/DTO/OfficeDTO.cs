using System.Collections.Generic;

namespace ConsidKompetens_Core.DTO
{
  public class OfficeDto:BaseDto
  {
    public string City { get; set; }
    public string TelephoneNumber { get; set; }
    public List<ProfileDto> ProfileDtos { get; set; }
  }
}
