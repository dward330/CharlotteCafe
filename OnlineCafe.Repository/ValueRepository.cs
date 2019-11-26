using OnlineCafe.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCafe.Repository
{
  public class ValueRepository : IValueRepository
  {
    public string GetValue()
    {
      return "Value";
    }
  }
}
