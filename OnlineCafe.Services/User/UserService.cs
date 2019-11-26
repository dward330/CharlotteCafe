using OnlineCafe.Interfaces.Repository;
using OnlineCafe.Interfaces.Services.User;
using OnlineCafe.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCafe.Services.User
{
  public class UserService : IUserService
  {
    //User GetUserByName(string name);

    //User GetUserById(string userId);

    //IEnumerable<User> GetUsers();

    private readonly IUserDataProvider _userDataProvider;
    public UserService(IUserDataProvider userDataProvider) {
      _userDataProvider = userDataProvider;
    }


    public IEnumerable<Models.User> GetUserById(string userId)
    {

      IEnumerable<Models.User> data = null;
      try
      {
        data = _userDataProvider.GetUserById(userId);
      }
      catch (Exception)
      {
        data = null;
        throw;
      }

      return data;
    }
  }
}
