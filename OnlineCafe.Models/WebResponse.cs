using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCafe.Models
{
  public class WebResponse
  {
    public enum Result { Success = 0, Failed = 1, Unknown = 2 };
    public Result status { get; set; }
    public string ErrorMessage { get; set; }
    public string ErrorStackTrace { get; set; }
   }
}
