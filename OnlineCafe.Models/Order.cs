using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineCafe.Models
{
    public class Order
    {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long ID { get; set; }
      public string Status { get; set; }
      public long UserID { get; set; }
      public User User { get; set; }
      public List<LineItem> LineItems { get; set; }
      public string Instructions { get; set; }
      public decimal Price { get; set; }
  }
}
