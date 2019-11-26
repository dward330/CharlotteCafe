using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineCafe.Models;
using OnlineCafe.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace OnlineCafe.Repository.Menu
{
  public class OnlineCafeDataProviderDatabase: DbContext, IOnlineCafeDataProvider
  {
    public DbSet<OnlineCafe.Models.Menu> Menus { get; set; }
    public DbSet<OnlineCafe.Models.MenuItem> MenuItems { get; set; }
    public DbSet<OnlineCafe.Models.Order> Orders { get; set; }
    public DbSet<OnlineCafe.Models.LineItem> lineItems { get; set; }
    public DbSet<OnlineCafe.Models.User> Users { get; set; }

    public OnlineCafeDataProviderDatabase(DbContextOptions<OnlineCafeDataProviderDatabase> options) : base(options)
    {
      Database.EnsureCreated();
    }

    public IEnumerable<OnlineCafe.Models.Menu> GetAllMenus()
    {
      return Menus;
    }

    public IEnumerable<Models.MenuItem> GetAllMenuItems()
    {
      return MenuItems;
    }

    public IEnumerable<LineItem> GetAllLineItems()
    {
      var menuItems = this.GetAllMenuItems();

      foreach (var lineItem in this.lineItems)
      {
        lineItem.MenuItem = (from record in menuItems where record.Id == lineItem.MenuItemId select record).FirstOrDefault();
      }


      return lineItems;
    }

    public IEnumerable<Models.Order> GetAllOrders()
    {
      var lineItems = this.GetAllLineItems();
      var users = this.GetAllUsers();
      
      foreach (var order in this.Orders)
      {
        order.LineItems = (from record in lineItems where record.OrderId == order.ID select record).ToList();
        order.User = (from record in users where record.Id == order.UserID select record).FirstOrDefault();
      }

      return this.Orders;
    }

    public IEnumerable<Models.User> GetAllUsers()
    {
      return Users;
    }

    public void SaveOrder(Models.Order newOrder)
    { 
      this.Orders.Add(newOrder);
      this.SaveChanges();
    }
  }
}
