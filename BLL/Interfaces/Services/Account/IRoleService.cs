using BLL.DTO.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Services.Account
{
   public interface IRoleService
   {
      void AddRole(string roleName);
      RoleDTO GetRole(string roleName);
      IEnumerable<RoleDTO> GetAll();
   }
}
