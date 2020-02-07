using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ConsidKompetens_Web.Models
{
  public class RegisterModelReq
  {
    [Required]
    [EmailAddress]
    public string UserName { get; set; }
    [Required]
    public string PassWord { get; set; }
    public PasswordOptions PasswordOptions { get; set; }

    //public RegisterModelReq()
    //{
    //  PasswordOptions.RequireLowercase = true;
    //  PasswordOptions.RequireUppercase = true;
    //  PasswordOptions.RequireNonAlphanumeric = true;
    //  PasswordOptions.RequiredLength = 8;
    //}
  }
}