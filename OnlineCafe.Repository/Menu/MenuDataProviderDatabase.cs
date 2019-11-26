using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineCafe.Models;
using OnlineCafe.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace OnlineCafe.Repository.Menu
{
  public class MenuDataProviderDatabase: IMenuDataProvider
  {
    private readonly IOnlineCafeDataProvider _onlineCafeDataProvider;

    public MenuDataProviderDatabase(IOnlineCafeDataProvider onlineCafeDataProvider)
    {
      this._onlineCafeDataProvider = onlineCafeDataProvider;
    }

    public IEnumerable<OnlineCafe.Models.Menu> GetAllMenus()
    {
      return this._onlineCafeDataProvider.GetAllMenus();
    }

  }
}
