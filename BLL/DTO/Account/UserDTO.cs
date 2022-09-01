﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Account
{
   public class UserDTO
   {
      public Guid Id { get; set; }
      public string Login { get; set; }
      public string Password { get; set; }
      public RoleDTO Role { get; set; }
   }
}