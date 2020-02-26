using System.Threading.Tasks;
using ConsidKompetens_Services.Helpers;
using Microsoft.AspNetCore.Identity;

namespace ConsidKompetens_Services.Interfaces
{
  public interface ILoginService
  {
    string GenerateToken(IdentityUser user);
    Task<IdentityUser> ValidateUserAsync(string userName, string passWord);
    Task<bool> LogOutUserAsync();
  }
}