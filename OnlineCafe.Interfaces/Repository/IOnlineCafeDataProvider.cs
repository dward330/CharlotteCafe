using OnlineCafe.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCafe.Interfaces.Repository
{
  public interface IOnlineCafeDataProvider
  {
    IEnumerable<Menu> GetAllMenus();
    IEnumerable<MenuItem> GetAllMenuItems();
    IEnumerable<LineItem> GetAllLineItems();
    IEnumerable<Order> GetAllOrders();
    IEnumerable<User> GetAllUsers();
    void SaveOrder(Order newOrder);
  }
}
