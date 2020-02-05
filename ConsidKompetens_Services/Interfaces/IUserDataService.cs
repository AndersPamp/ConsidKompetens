using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.Models;

namespace ConsidKompetens_Services.Interfaces
{
  public interface IUserDataService
  {
    Task<List<EmployeeUserModel>> GetAllUsersAsync();
    Task<EmployeeUserModel> GetUserByIdAsync(int id);
    Task<EmployeeUserModel> EditUserByIdAsync(int id, EmployeeUserModel userModel);
    Task<EmployeeUserModel> CreateNewUserAsync(EmployeeUserModel userModel);
  }
}