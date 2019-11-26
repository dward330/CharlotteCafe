using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCafe.Interfaces.Services.Menu
{
  public interface IMenuService
  {
    IEnumerable<OnlineCafe.Models.Menu> GetAllMenus();
    IEnumerable<OnlineCafe.Models.Menu> GetMenuById(long id);
  }
}
