using OnlineCafe.Interfaces.Repository;
using OnlineCafe.Interfaces.Services.Menu;
using OnlineCafe.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCafe.Services.Menu
{
  public class MenuItemService : IMenuItemService
  {
    private readonly IMenuItemDataProvider _menuItemDataProvider;

    public MenuItemService(IMenuItemDataProvider menuItemDataProvider)
    {
      _menuItemDataProvider = menuItemDataProvider;
    }

    public IEnumerable<MenuItem> GetAllMenuItems()
    {
      IEnumerable<Models.MenuItem> data = null;

      try
      {
        data = this._menuItemDataProvider.GetAllMenuItems();
      }
      catch (Exception e)
      {
        data = null;
        Console.WriteLine($"Error Occured: {e}");
      }

      return data;
    }

    public IEnumerable<MenuItem> GetMenuItemById(long id)
    {
      return new List<MenuItem>();
    }

    //Item GetItemById(string itemId);
  }
}
