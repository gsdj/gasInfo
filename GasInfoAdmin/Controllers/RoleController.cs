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

      public RoleController(ILogger<RoleController> logger)
      {
         _logger = logger;
      }

      public IActionResult Index()
      {
         return View();
      }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error()
      {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}
