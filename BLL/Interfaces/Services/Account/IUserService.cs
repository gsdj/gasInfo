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
      void EditUser(int id);
      UserDTO GetUser(int id);
      IEnumerable<UserDTO> GetAll();
   }
}
