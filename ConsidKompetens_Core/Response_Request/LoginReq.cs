using System.ComponentModel.DataAnnotations;

namespace ConsidKompetens_Core.Response_Request
{
  public class LoginReq
  {
    [Required]
    [EmailAddress]
    public string UserName { get; set; }
    [Required]
    public string PassWord { get; set; }
  }
}