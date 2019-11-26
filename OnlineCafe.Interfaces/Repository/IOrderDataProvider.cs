using OnlineCafe.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCafe.Interfaces.Repository
{
  public interface IOrderDataProvider
  {
    IEnumerable<Order> GetAllOrders();

    void SaveOrder(Order newOrder);
  }
}
