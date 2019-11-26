using OnlineCafe.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCafe.Interfaces.Services.Order
{
  public interface IOrderService
  {
    IEnumerable<Models.Order> GetAllOrders();

    WebResponse SaveOrder(Models.Order newOrder);

    //Order GetOrder(string orderId);

    //Status GetOrderStatus(string orderId);

    //CancelOrder(OrderId);
  }
}
