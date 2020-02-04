using System;
using System.Threading.Tasks;
using ConsidKompetens_Core.Models;

namespace ConsidKompetens_Services.Interfaces
{
  public interface IUserDataService
  {
    Task<EmployeeUserModel> GetUserByIdAsync(Guid id);
    Task<EmployeeUserModel> EditUserByIdAsync(EmployeeUserModel userModel);
    Task<EmployeeUserModel> CreateNewUserAsync(EmployeeUserModel userModel);
  }
}