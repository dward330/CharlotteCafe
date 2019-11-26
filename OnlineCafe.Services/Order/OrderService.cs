using System;
using System.Collections.Generic;
using System.Text;
using OnlineCafe.Interfaces;
using OnlineCafe.Interfaces.Repository;
using OnlineCafe.Interfaces.Services.Order;
using OnlineCafe.Models;

namespace OnlineCafe.Services.Order
{
  public class OrderService : IOrderService
  {
    private readonly IOrderDataProvider _orderDataProvider;

    public OrderService(IOrderDataProvider orderDataProvider)
    {
      _orderDataProvider = orderDataProvider;
    }

    //Order GetOrder(string orderId);

    //Status GetOrderStatus(string orderId);

    //CancelOrder(OrderId);

    /// <summary>
    /// Gets all orders.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Models.Order> GetAllOrders()
    {
      IEnumerable<OnlineCafe.Models.Order> data = null;

      try
      {
        data = this._orderDataProvider.GetAllOrders();
      }
      catch (Exception e)
      {
        data = null;
        Console.WriteLine($"Error Occured: {e.ToString()}");
      }

      return data;
    }

    /// <summary>
    /// Saves the order.
    /// </summary>
    /// <param name="newOrder">The new order.</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public WebResponse SaveOrder(Models.Order newOrder)
    {
      WebResponse response = new WebResponse();

      try
      {
        //Try to save Data
        this._orderDataProvider.SaveOrder(newOrder);

        response.status = WebResponse.Result.Success;
      }
      catch (Exception e)
      {
        response.status = WebResponse.Result.Failed;
        response.ErrorMessage = e.ToString();
        response.ErrorStackTrace = e.StackTrace;
      }

      return response;
    }
  }
}
