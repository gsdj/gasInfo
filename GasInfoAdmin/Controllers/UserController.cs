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
   public class UserController : Controller
   {
      private readonly ILogger<UserController> _logger;
      private IUserService Users;

      public UserController(ILogger<UserController> logger, IUserService users)
      {
         _logger = logger;
         Users = users;
      }

      public IActionResult Index()
      {
         var U = Users.GetAll();
         return View(U);
      }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error()
      {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}
