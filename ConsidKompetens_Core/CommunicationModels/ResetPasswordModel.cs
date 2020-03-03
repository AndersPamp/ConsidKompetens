using System.ComponentModel.DataAnnotations;

namespace ConsidKompetens_Core.CommunicationModels
{
  public class ResetPasswordModel
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