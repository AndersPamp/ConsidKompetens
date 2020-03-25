using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsidKompetens_Core.DTO
{
  public class ProfileDto:BaseDto
  {
    public string OwnerID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string AboutMe { get; set; }
    public string Position { get; set; }
    [ForeignKey("OfficeDto")]
    public int OfficeDtoFK { get; set; }
    public int ImageModelId { get; set; }
    public ImageDto ImageModel { get; set; }
    public ICollection<CompetenceDto> Competences { get; set; }
    public ushort Experience { get; set; }
    public string LinkedInUrl { get; set; }
    public string ResumeUrl { get; set; }
  }
}
