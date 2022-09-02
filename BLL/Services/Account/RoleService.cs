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
   public class RoleService : IRoleService
   {
      private IGenericRepository<Role> RolesRep;
      public RoleService(IGenericRepository<Role> rep)
      {
         RolesRep = rep;
      }
      public void AddRole(string roleName)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<RoleDTO> GetAll()
      {
         throw new NotImplementedException();
      }

      public RoleDTO GetRole(string roleName)
      {
         throw new NotImplementedException();
      }
   }
}
