using System.ComponentModel.DataAnnotations;

namespace ConsidKompetens_Core.CommunicationModels
{
  public class LoginModelReq
  {
    [Required]
    [EmailAddress]
    public string UserName { get; set; }
    [Required]
    public string PassWord { get; set; }
  }
}