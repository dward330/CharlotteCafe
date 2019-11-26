using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineCafe.Models
{
  public class LineItem
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public long MenuItemId { get; set; }
    public MenuItem MenuItem { get; set; }
    public long OrderId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public bool Favorite { get; set; }
    public Size ItemSize { get; set; }
    
    public enum Size
    {
      Tall = 1, Grande, Venti
    }
    
  }
}
