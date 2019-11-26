using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using OnlineCafe.Interfaces.Repository;
using OnlineCafe.Models;

namespace OnlineCafe.Repository.Order
{
  public class OrderDataProviderDatabase : DbContext, IOrderDataProvider
  {
    private readonly IOnlineCafeDataProvider _onlineCafeDataProvider;

    public OrderDataProviderDatabase(IOnlineCafeDataProvider onlineCafeDataProvider)
    {
      this._onlineCafeDataProvider = onlineCafeDataProvider;
    }

    public IEnumerable<Models.Order> GetAllOrders()
    {
      return this._onlineCafeDataProvider.GetAllOrders();
    }

    public void SaveOrder(Models.Order newOrder)
    {
      this._onlineCafeDataProvider.SaveOrder(newOrder);
    }
  }
}
