using System.ComponentModel.DataAnnotations;

namespace ConsidKompetens_Core.Response_Request
{
  public class RegisterReq
  {
    [Required]
    [EmailAddress]
    public string UserName { get; set; }
    [Required]
    public string PassWord { get; set; }
  }
}