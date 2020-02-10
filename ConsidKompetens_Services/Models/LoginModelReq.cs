using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ConsidKompetens_Web.Models
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