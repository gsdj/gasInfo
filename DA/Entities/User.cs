﻿using DA.Interfaces;
using System;

namespace DA.Entities
{
   public class User : IEntity
   {
      public int Id { get; set; }
      public string Login { get; set; }
      public string Password { get; set; }
      public int? RoleId { get; set; }
      public Role Role { get; set; }
   }
}
