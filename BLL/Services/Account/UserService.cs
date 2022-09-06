using BLL.DTO.Account;
using BLL.Interfaces.Services.Account;
using DA.Entities;
using DA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Account
{
   public class UserService : IUserService
   {
      private IGenericRepository<User> UsersRep;
      public UserService(IGenericRepository<User> rep)
      {
         UsersRep = rep;
      }
      public void AddUser(UserDTO newUser)
      {
         User U = new User()
         {
            Login = newUser.Login,
            Password = PasswordToHex(newUser.Login + newUser.Password),
            RoleId = newUser.Role.Id,
         };

         UsersRep.Create(U);
      }

      public void DeleteUser(int id)
      {
         var u = UsersRep.GetById(id);
         UsersRep.Delete(u);
      }

      public IEnumerable<UserDTO> GetAll()
      {
         return UsersRep.GetAll().Select(x => ToDTO(x));
      }

      public UserDTO GetUser(int id)
      {
         var user = ToDTO(UsersRep.GetById(id));
         return user;
      }

      private UserDTO ToDTO(User user)
      {
         return new UserDTO
         {
            Id = user.Id,
            Login = user.Login,
            Password = user.Password,
            Role = new RoleDTO
            {
               Id = user.Role.Id,
               Name = user.Role.Name,
            },
         };
      }
      private string PasswordToHex(string str)
      {
         SHA256 sha = SHA256.Create();

         var hash = sha.ComputeHash(Encoding.UTF8.GetBytes(str));

         var shaPass = new StringBuilder();

         for (int i = 0; i < hash.Length; i++)
         {
            shaPass.Append(hash[i].ToString("x2"));
         }
         return shaPass.ToString();
      }

      public IEnumerable<UserDTO> GetByRoleId(int id)
      {
         var users = UsersRep.Get(x => x.RoleId == id).Select(x => ToDTO(x));
         return users;
      }
   }
}
