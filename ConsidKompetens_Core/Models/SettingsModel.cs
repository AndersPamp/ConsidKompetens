namespace ConsidKompetens_Core.Models
{
  public class SettingsModel : BaseEntity
  {
    public string WebsiteName { get; set; }
    public ImageModel WebsiteLogo { get; set; }
  }
}