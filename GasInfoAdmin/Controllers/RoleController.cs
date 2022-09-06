using BLL.Interfaces.Services.Account;
using GasInfoAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GasInfoAdmin.Controllers
{
   public class RoleController : Controller
   {
      private readonly ILogger<RoleController> _logger;
      private IRoleService Roles;

      public RoleController(ILogger<RoleController> logger, IRoleService roles)
      {
         _logger = logger;
         Roles = roles;
      }

      public IActionResult Index()
      {
         var roles = Roles.GetAll();
         return View(roles);
      }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error()
      {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}
