using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using OnlineCafe.Api.DAL.Menu;
//using OnlineCafe.Api.DAL.MenuItem;
using OnlineCafe.Interfaces.Repository;
using OnlineCafe.Interfaces.Services.Lineitem;
using OnlineCafe.Interfaces.Services.Menu;

namespace OnlineCafe.Api.Controllers
{
  
  [Produces("application/json")]
  [Route("api/Menu")]
  public class MenuController : Controller
  {
    private readonly IMenuService _menuService;
    private readonly IMenuItemService _menuItemService;

    public MenuController(IMenuService menuService, IMenuItemService menuItemService)
    {
      _menuService = menuService;
      _menuItemService = menuItemService;
    }

    [HttpGet("all")]
    public JsonResult AllMenus()
    {
      return Json(_menuService.GetAllMenus());
    }

    [HttpGet("{id}")]
    public JsonResult MenuById(long id)
    {
      return Json(_menuService.GetMenuById(id));
    }

    [HttpGet("MenuItems/all")]
    public JsonResult AllMenuItems()
    {
      return Json(_menuItemService.GetAllMenuItems());
    }

    [HttpGet("MenuItems/{id}")]
    public JsonResult MenuItemById(long id)
    {
      return Json(_menuItemService.GetMenuItemById(id));
    }
  }
}
