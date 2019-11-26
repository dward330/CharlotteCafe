using OnlineCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCafe.Interfaces.Repository
{
  public interface IMenuItemDataProvider
  {
    IEnumerable<MenuItem> GetAllMenuItems();
  }
}
