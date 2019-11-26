using System;
using System.IO;
using System.Collections.Generic;
using OnlineCafe.Models;
using OnlineCafe.Interfaces.Services.Lineitem;
using OnlineCafe.Services.Order;
using OnlineCafe.Repository.Order;

namespace OnlineCafe.Sandbox
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        Console.WriteLine("Generating Json Mock Data for Online Cafe.");

        Console.Write("Generating and Writing Menu Mock Data....");
        Console.Write((GenerateMenuMockData()) ? "Finished!" : "Failed" );

        Console.Write("\nGenerating and Writing Menu Item Mock Data....");
        Console.Write((GenerateMenuItemMockData()) ? "Finished!" : "Failed");


        Console.Write("\nGenerating and Writing Order Mock Data....");
        Console.Write((GenerateOrderMockData()) ? "Finished!" : "Failed");

        Console.Write("\nGenerating and Writing Line Item Mock Data....");
        Console.Write((GenerateLineItemMockData()) ? "Finished!" : "Failed");
        /*
        ILineItemService liService = new LineItemService(new LineItemDataProviderFile());
        IEnumerable<LineItem> data = liService.GetAllLineItems();
        foreach (LineItem item in data)
        {
          Console.WriteLine($"Price: {item.Price}");
        }
        */
      }
      catch (Exception e)
      {
        LogError(e.ToString());
      }

      Console.WriteLine("\n\nPress any key to exit program....");
      Console.ReadKey();
    }

    public static bool GenerateMenuItemMockData()
    {
      bool successful = false;

      try
      {
        MenuItem MenuItem = new MenuItem() { Id = 1, Name = "Americano", Description = "...", Active = true, Price = (Decimal)5.00 };
        
        var mockData = Utf8Json.JsonSerializer.Serialize<MenuItem>(MenuItem);
        File.WriteAllBytes("./MockData/MockMenuItemData.json", mockData);

        successful = true;
      }
      catch (Exception e)
      {
        successful = false;
        LogError(e.ToString());
      }

      return successful;
    }

    public static bool GenerateMenuMockData()
    {
      bool successful = false;

      try
      {
        MenuItem MenuItem = new MenuItem() { Id = 1, Name = "Americano", Description = "...", Active = true, Price = (Decimal)5.00 };
        Menu Menu = new Menu() { Id = 1, VendorId = 1, Items = new List<MenuItem>() };
        Menu.Items.Add(MenuItem);

        var mockData = Utf8Json.JsonSerializer.Serialize<Menu>(Menu);
        File.WriteAllBytes("./MockData/MockMenuData.json", mockData);

        successful = true;
      }
      catch (Exception e)
      {
        successful = false;
        LogError(e.ToString());
      }

      return successful;
    }

    public static bool GenerateLineItemMockData()
    {
      bool successful = false;

      try
      {
        // User User = new User { Id = 1, FirstName = "Joe", LastName = "Mama", Alias = "jomama", PhoneNo = "5558675309" };
        MenuItem MenuItem = new MenuItem() { Id = 1, Name = "Americano", Description = "...", Active = true, Price = (Decimal)5.00 };
        LineItem LineItem = new LineItem() { Id = 1, MenuItemId = 1, MenuItem = MenuItem, Price = (Decimal)4.50, Quantity = 1, Favorite = true, ItemSize = LineItem.Size.Grande};

        var mockData = Utf8Json.JsonSerializer.Serialize<LineItem>(LineItem);
        File.WriteAllBytes("./MockData/MockLineItemData.json", mockData);

        successful = true;
      }
      catch (Exception e)
      {
        successful = false;
        LogError(e.ToString());
      }

      return successful;
    }

    public static bool GenerateOrderMockData()
    {
      bool successful = false;

      try
      {
        User User = new User { Id = 1, FirstName = "Joe", LastName = "Mama", Alias = "jomama", PhoneNo = "5558675309" };
        MenuItem MenuItem = new MenuItem() { Id = 1, Name = "Americano", Description = "...", Active = true, Price = (Decimal)5.00 };
        List<LineItem> lineItems = new List<LineItem>();
        LineItem LineItem = new LineItem() { Id = 1, MenuItemId = 1, MenuItem = MenuItem, Price = (Decimal)4.50, Quantity = 1, Favorite = true, ItemSize = LineItem.Size.Grande };
        lineItems.Add(LineItem);
        Order Order = new Order() { ID = 100, Status = "New", UserID = 123456, LineItems = lineItems, User = User, Instructions = "...", Price = (Decimal)5.00 };

        var mockData = Utf8Json.JsonSerializer.Serialize<Order>(Order);
        File.WriteAllBytes("./MockData/MockOrderData.json", mockData);
        
        successful = true;
      }
      catch (Exception e)
      {
        successful = false;
        LogError(e.ToString());
      }

      return successful;
    }

    public static void LogError(String error)
    {
      Console.WriteLine($"Error Occurred: {error}");
    }
  }
}
