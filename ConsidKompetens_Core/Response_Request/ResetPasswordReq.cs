using System.ComponentModel.DataAnnotations;

namespace ConsidKompetens_Core.Response_Request
{
  public class ResetPasswordReq
  {
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public string Token { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
  }
}