using System.ComponentModel.DataAnnotations;

namespace ConsidKompetens_Web.Models
{
  public class RegisterModelReq
  {
    [Required]
    [EmailAddress]
    public string UserName { get; set; }
    [Required]
    public string PassWord { get; set; }
  }
}