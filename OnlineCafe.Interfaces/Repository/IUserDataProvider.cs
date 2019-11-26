using OnlineCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCafe.Interfaces.Repository
{
    public interface IUserDataProvider
    {
      IEnumerable<User> GetUserById(string id);
    }
}
