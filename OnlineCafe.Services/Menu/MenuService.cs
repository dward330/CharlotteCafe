using OnlineCafe.Interfaces.Repository;
using OnlineCafe.Interfaces.Services.Menu;
using OnlineCafe.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCafe.Services.Menu
{
  public class MenuService : IMenuService
  {
    private readonly IMenuDataProvider _menuDataProvider;

    public MenuService(IMenuDataProvider menuDataProvider)
    {
      _menuDataProvider = menuDataProvider;
    }

    public IEnumerable<OnlineCafe.Models.Menu> GetAllMenus()
    {
      IEnumerable<Models.Menu> data = null;

      try
      {
        data = this._menuDataProvider.GetAllMenus();
      }
      catch (Exception e)
      {
        data = null;
        Console.WriteLine($"Error Occured: {e}");
      }

      return data;
    }

    public IEnumerable<Models.Menu> GetMenuById(long id)
    {
      return new List<Models.Menu>();
    }
  }
}
