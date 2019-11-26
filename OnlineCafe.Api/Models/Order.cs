using System;
using Microsoft.Bot.Builder.FormFlow;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCafe.Api.Models
{
    public enum CoffeeType
    {
      CafeLatte = 1,
      Cappuccino,
      Decaf,
      IcedCoffee,
      Espresso,
      Americano
    }

    public enum Size
    {
      Small = 1,
      Medium = 2,
      Large = 3
    }

    [Serializable]
    public class Order
    {
      [Describe("Drink")]
      public CoffeeType CoffeeType;

      public Size Size;

      [Prompt("Any special instructions?")]
      public string SpecialInstructions;


      public static IForm<Order> BuildForm()
      {
        return new FormBuilder<Order>().Message("Sure! Lets get started with your order.").Build();
      }
    }
 
}
