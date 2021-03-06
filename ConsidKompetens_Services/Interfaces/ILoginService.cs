﻿using System.Threading.Tasks;
using ConsidKompetens_Core.Response_Request;
using Microsoft.AspNetCore.Identity;

namespace ConsidKompetens_Services.Interfaces
{
  public interface ILoginService
  {
    string GenerateToken(IdentityUser user);
    Task<IdentityUser> ValidateUserAsync(string userName, string passWord);
    Task<bool> LogOutUserAsync();
    Task<bool> SendResetPasswordEmailAsync(string email, string link);
    Task<bool> ResetPasswordAsync(ResetPasswordReq input);
    Task<string> GenerateResetTokenAsync(IdentityUser user);
    Task<IdentityUser> FindUserByEmailAsync(string email);
  }
}