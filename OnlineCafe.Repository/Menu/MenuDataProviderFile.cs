using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using OnlineCafe.Models;
using OnlineCafe.Interfaces.Repository;
using System.Reflection;

namespace OnlineCafe.Repository.Menu {
  public class MenuDataProviderFile : IMenuDataProvider
  {
    private readonly String filepath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\MockData\\MockMenuData.json";

    /// <summary>
    /// Gets all menus from file
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Models.Menu> GetAllMenus()
    {
      IEnumerable<Models.Menu> data = Utf8Json.JsonSerializer.Deserialize<IEnumerable<OnlineCafe.Models.Menu>>(File.ReadAllBytes(filepath));
      
      return data;
    }
  }
}
