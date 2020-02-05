using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Data.Data;
using ConsidKompetens_Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConsidKompetens_Services.DataServices
{
  public class UserDataService : IUserDataService
  {
    private readonly UserDataContext _userDataContext;

    public UserDataService(UserDataContext userDataContext)
    {
      _userDataContext = userDataContext;
    }

    public async Task<List<EmployeeUserModel>> GetAllUsersAsync()
    {
      try
      {
        return await _userDataContext.EmployeeUsers.ToListAsync();
      }
      catch (Exception e)
      {
        
        throw new Exception(e.Message);
      }
    }

    public async Task<EmployeeUserModel> GetUserByIdAsync(int id)
    {
      try
      {
        return await _userDataContext.EmployeeUsers.FindAsync(id);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }

    }

    public async Task<EmployeeUserModel> EditUserByIdAsync(int id, EmployeeUserModel userModel)
    {
      try
      {
        var user = await _userDataContext.EmployeeUsers.FindAsync(userModel.Id);
        user.AboutMe = userModel.AboutMe;
        user.ProfileImage = userModel.ProfileImage;
        _userDataContext.EmployeeUsers.Update(user);
        await _userDataContext.SaveChangesAsync();
        return userModel;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<EmployeeUserModel> CreateNewUserAsync(EmployeeUserModel userModel)
    {
      try
      {
        var newUserModel = new EmployeeUserModel()
        {
          AboutMe = userModel.AboutMe,
          ProfileImage = userModel.ProfileImage,
          Competences = userModel.Competences
        };
        await _userDataContext.EmployeeUsers.AddAsync(newUserModel);
        await _userDataContext.SaveChangesAsync();

        return userModel;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
  }
}
