using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using OnlineCafe.Interfaces.Repository;
using OnlineCafe.Models;

namespace OnlineCafe.Repository.Order
{
    public class OrderDataProviderFile : IOrderDataProvider
    {
    private readonly String filepath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\MockData\\MockOrderData.json";

    /// <summary>
    /// Gets all orders from file
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Models.Order> GetAllOrders()
    {
      IEnumerable<Models.Order> data = Utf8Json.JsonSerializer.Deserialize<IEnumerable<OnlineCafe.Models.Order>>(File.ReadAllBytes(filepath));

      return data;
    }

    void IOrderDataProvider.SaveOrder(Models.Order newOrder)
    {
      throw new NotImplementedException();
    }
  }
}
