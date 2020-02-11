﻿using System.Threading.Tasks;
using ConsidKompetens_Web.Models;
using Microsoft.AspNetCore.Identity;

namespace ConsidKompetens_Services.Interfaces
{
  public interface IRegisterService
  {
    Task<bool> CheckIfUserExistsAsync(string userName);
    Task<bool> RegisterNewUserAsync(RegisterModelReq newModel);
  }
}