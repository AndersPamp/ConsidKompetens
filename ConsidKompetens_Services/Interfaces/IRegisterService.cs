﻿using System.Threading.Tasks;
using ConsidKompetens_Core.CommunicationModels;
using Microsoft.AspNetCore.Identity;

namespace ConsidKompetens_Services.Interfaces
{
  public interface IRegisterService
  {
    Task<bool> CheckIfUserExistsAsync(string userName);
    Task<IdentityUser> RegisterNewUserAsync(RegisterModelReq newModel);
    Task SendEmailConfirmationAsync(IdentityUser user, string link);
  }
}