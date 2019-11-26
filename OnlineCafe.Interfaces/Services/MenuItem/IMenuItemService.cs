using OnlineCafe.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCafe.Interfaces.Services.Menu
{
  public interface IMenuItemService
  {
    IEnumerable<MenuItem> GetAllMenuItems();

    IEnumerable<MenuItem> GetMenuItemById(long id);
  }
}
