using System.Collections.Generic;

namespace ConsidKompetens_Core.DTO
{
  public class ProfileDTO:BaseDTO
  {
    public string OwnerID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string AboutMe { get; set; }
    public string Position { get; set; }
    public int ImageModelId { get; set; }
    public ImageDTO ImageModel { get; set; }
    public ICollection<CompetenceDTO> Competences { get; set; }
    public ushort Experience { get; set; }
    public string LinkedInUrl { get; set; }
    public string ResumeUrl { get; set; }
  }
}
