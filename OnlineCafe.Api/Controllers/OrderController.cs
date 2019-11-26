using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCafe.Interfaces.Services.Lineitem;
using OnlineCafe.Interfaces.Services.Order;
using OnlineCafe.Models;

namespace OnlineCafe.Api.Controllers
{
  
  [Produces("application/json")]
  [Route("api/Order")]
  public class OrderController : Controller
  {
    private readonly ILineItemService _lineItemService;
    private readonly IOrderService _orderService;

    public OrderController(ILineItemService lineItemService, IOrderService orderService)
    {
      _lineItemService = lineItemService;
      _orderService = orderService;
    }

    [HttpGet("LineItems/all")]
    public JsonResult GetAllLineItems()
    {
      return Json(this._lineItemService.GetAllLineItems());
    }

    [HttpGet("all")]
    public JsonResult GetAllOrders()
    {
      return Json(this._orderService.GetAllOrders());
    }

    [HttpPost("Save")]
    public JsonResult SaveOrder([FromBody]Order newOrder)
    {
      if (null != newOrder)
      {
        return Json(this._orderService.SaveOrder(newOrder));
      }
      else
      {
        WebResponse response = new WebResponse();
        response.status = WebResponse.Result.Failed;
        response.ErrorMessage = "No Order Found in Body of Post Request!";

        return Json(response);
      }
    }
  }
}
