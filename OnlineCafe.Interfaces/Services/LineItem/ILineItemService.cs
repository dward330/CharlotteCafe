using OnlineCafe.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCafe.Interfaces.Services.Lineitem
{
  public interface ILineItemService
  {
    IEnumerable<LineItem> GetAllLineItems();
  }
}
