using BLL.DTO.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Services.Account
{
   public interface IUserService
   {
      void AddUser(UserDTO newUser);
      void DeleteUser(int id);
      UserDTO GetUser(int id);
      IEnumerable<UserDTO> GetByRoleId(int id);
      IEnumerable<UserDTO> GetAll();
   }
}
