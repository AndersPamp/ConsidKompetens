using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ConsidKompetens_Services.Interfaces
{
  public interface ILoginService
  {
    string GenerateToken(IdentityUser user);
    Task<IdentityUser> ValidateUserAsync(string userName, string passWord);
    Task<bool> LogOutUserAsync();
  }
}