using System.Collections.Generic;

namespace ConsidKompetens_Core.Models
{
  public class ProfileModel : BaseEntity
  {
    public string OwnerID { get; set; }
    public int OfficeModelId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string AboutMe { get; set; }
    public string Title { get; set; }
    public int ImageModelId { get; set; }
    public ImageModel ImageModel { get; set; }
    public ICollection<CompetenceModel> Competences { get; set; }
    public ushort Experience { get; set; }
    public ICollection<ProjectProfileRole> ProjectProfileRoles { get; set; }
  }
}