using OnlineCafe.Interfaces.Repository;
using OnlineCafe.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCafe.Repository.User
{
  public class UserDataProviderFile : IUserDataProvider
  {
    private readonly String filepath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\MockData\\MockUserData.json";
    public IEnumerable<Models.User> GetUserById(string id)
    {
      IEnumerable<Models.User> user = null;

      try
      {
        user = Utf8Json.JsonSerializer.Deserialize<IEnumerable<OnlineCafe.Models.User>>(File.ReadAllBytes(filepath))
          .Where(u => u.Id.Equals(long.Parse(id)));
      }
      catch (Exception e)
      {

        user = null;
        Console.WriteLine($"Error Occured: {e}");
      }

      return user;

    }
  }
}
