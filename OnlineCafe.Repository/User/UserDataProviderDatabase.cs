using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using OnlineCafe.Interfaces.Repository;
using OnlineCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCafe.Repository.User
{
  public class UserDataProviderDatabase : DbContext, IUserDataProvider
  {
    private readonly IOnlineCafeDataProvider _onlineCafeDataProvider;

    public UserDataProviderDatabase(IOnlineCafeDataProvider onlineCafeDataProvider)
    {
      this._onlineCafeDataProvider = onlineCafeDataProvider;
    }

    public IEnumerable<Models.User> GetAllUsers()
    {
      return this._onlineCafeDataProvider.GetAllUsers();
    }

    public IEnumerable<Models.User> GetUserById(string id)
    {
      return new List<Models.User>();
    }
  }
}
