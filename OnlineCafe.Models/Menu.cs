using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCafe.Models
{
  public class Menu
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long VendorId { get; set; }

    public string Name { get; set; }

    public string ImageUrl { get; set; }

    public List<MenuItem> Items { get; set; }
  }
}
