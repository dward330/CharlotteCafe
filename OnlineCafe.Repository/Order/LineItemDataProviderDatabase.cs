using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using OnlineCafe.Interfaces.Repository;
using OnlineCafe.Models;

namespace OnlineCafe.Repository.Order
{
  public class LineItemDataProviderDatabase : DbContext, ILineItemDataProvider
  {
    private readonly IOnlineCafeDataProvider _onlineCafeDataProvider;

    public LineItemDataProviderDatabase(IOnlineCafeDataProvider onlineCafeDataProvider)
    {
      this._onlineCafeDataProvider = onlineCafeDataProvider;
    }

    public IEnumerable<LineItem> GetAllLineItems()
    {
      return this._onlineCafeDataProvider.GetAllLineItems();
    }
  }
}
