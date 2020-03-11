using System.Threading.Tasks;
using ConsidKompetens_Core.Response_Request;
using Microsoft.AspNetCore.Identity;

namespace ConsidKompetens_Services.Interfaces
{
  public interface IRegisterService
  {
    Task<bool> CheckIfUserExistsAsync(string userName);
    Task<IdentityUser> CheckIfUserIdExistsAsync(string userId);
    Task<IdentityUser> RegisterNewUserAsync(RegisterReq newModel);
    Task SendEmailConfirmationAsync(IdentityUser user, string link);
    Task<string> GenerateEmailTokenAsync(IdentityUser user);
    Task<bool> ConfirmEmailAsync(string userId, string token);
  }
}