using OnlineCafe.Interfaces.Repository;
using OnlineCafe.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace OnlineCafe.Repository.Order
{
  public class LineItemDataProviderFile : ILineItemDataProvider
  {
    private readonly String filepath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\MockData\\MockLineItemData.json";

    public IEnumerable<LineItem> GetAllLineItems()
    {
      IEnumerable<LineItem> data = Utf8Json.JsonSerializer.Deserialize<List<LineItem>>(File.ReadAllBytes(filepath));

      return data;
    }
  }
}
