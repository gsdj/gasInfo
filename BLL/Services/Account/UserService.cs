using BLL.DTO.Account;
using BLL.Interfaces.Services.Account;
using DA.Entities;
using DA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
         throw new NotImplementedException();
      }

      public void DeleteUser(int id)
      {
         throw new NotImplementedException();
      }

      public void EditUser(int id)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<UserDTO> GetAll()
      {
         return UsersRep.GetAll().Select(x => ToDTO(x));
      }

      public UserDTO GetUser(int id)
      {
         throw new NotImplementedException();
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
   }
}
