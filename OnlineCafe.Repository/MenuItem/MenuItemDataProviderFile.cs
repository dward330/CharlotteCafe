using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using OnlineCafe.Models;
using OnlineCafe.Interfaces.Repository;
using System.Reflection;

namespace OnlineCafe.Repository.MenuItem
{
  public class MenuItemDataProviderFile : IMenuItemDataProvider
  {
    private readonly String filepath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\MockData\\MockMenuItemData.json";

    /// <summary>
    /// Gets all menu items from file
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Models.MenuItem> GetAllMenuItems()
    {
      IEnumerable<Models.MenuItem> data = Utf8Json.JsonSerializer.Deserialize<IEnumerable<OnlineCafe.Models.MenuItem>>(File.ReadAllBytes(filepath));

      return data;
    }
  }
}
