using Microsoft.AspNetCore.Mvc;
using OnlineCafe.Interfaces.Repository;
using OnlineCafe.Interfaces.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCafe.Api.Controllers
{
  [Produces("application/json")]
  [Route("api/[controller]")]
  public class UsersController : Controller
    {
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpGet("{id}")]
    public JsonResult UserById(string id)
    {
      var result = Json(_userService.GetUserById(id));
      return result;
    }
  }
}
