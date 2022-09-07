using BLL.DTO.Account;
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

      public IActionResult Index(int roleId)
      {
         var U = Users.GetByRoleId(roleId);
         ViewBag.RoleId = roleId;
         return View(U);
      }
      [HttpPost]
      public IActionResult AddUser(UserViewModel user)
      {
         UserDTO newuser = new UserDTO()
         {
            Login = user.Login,
            Password = user.Password,
            Role = new RoleDTO
            {
               Id = user.RoleId,
            }
         };
         Users.AddUser(newuser);
         //var U = Users.GetByRoleId(user.RoleId);
         return RedirectToAction("Index", new { roleId = user.RoleId });
         //return PartialView("Users", U);
      }
      //проверка update rep
      public void TestUpdate()
      {
         UserDTO updateUs = new UserDTO
         {
            Id = 2,
            Login = "updateUser",
            Password = "updatedUser",
            Role = new RoleDTO
            {
               Id = 1,
               Name = "Admin",
            }
         };
         Users.Update(updateUs);
      }
      [HttpDelete]
      public IActionResult DeleteUser(int id, int roleId)
      {
         Users.DeleteUser(id);
         var U = Users.GetByRoleId(roleId);
         return PartialView("Users", U);
      }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error()
      {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}
