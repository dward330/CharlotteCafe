using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCafe.Interfaces.Services.User
{
    public interface IUserService
    {
    //User GetUserByName(string name);

    IEnumerable<Models.User> GetUserById(string userId);

    //IEnumerable<User> GetUsers();
  }
}
