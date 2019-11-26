using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineCafe.Models;
using OnlineCafe.Interfaces.Repository;

namespace OnlineCafe.Repository.MenuItem
{
  public class MenuItemDataProviderDatabase : IMenuItemDataProvider
  {
    private readonly IOnlineCafeDataProvider _onlineCafeDataProvider;

    public MenuItemDataProviderDatabase(IOnlineCafeDataProvider onlineCafeDataProvider)
    {
      this._onlineCafeDataProvider = onlineCafeDataProvider;
    }

    public IEnumerable<OnlineCafe.Models.MenuItem> GetAllMenuItems()
    {
      return this._onlineCafeDataProvider.GetAllMenuItems();
    }
  }
}
