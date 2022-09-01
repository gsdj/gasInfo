﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Account
{
   public class RoleDTO
   {
      public Guid Id { get; set; }
      public string Name { get; set; }
      public List<UserDTO> Users { get; set; }
      public RoleDTO()
      {
         Users = new List<UserDTO>();
      }
   }
}