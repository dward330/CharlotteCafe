using OnlineCafe.Interfaces.Repository;
using OnlineCafe.Interfaces.Services.Lineitem;
using OnlineCafe.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCafe.Services.Order
{
  public class LineItemService : ILineItemService
  {
    private readonly ILineItemDataProvider _lineItemDataProvider;

    public LineItemService(ILineItemDataProvider lineItemDataProvider)
    {
      _lineItemDataProvider = lineItemDataProvider;
    }

    public IEnumerable<LineItem> GetAllLineItems()
    {
      IEnumerable<LineItem> data = null;

      try
      {
        data = this._lineItemDataProvider.GetAllLineItems();
      }
      catch (Exception e)
      {
        data = null;
        Console.WriteLine($"Error Occured: {e.ToString()}");
      }

      return data;
    }
  }
}
