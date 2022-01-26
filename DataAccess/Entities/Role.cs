﻿using DataAccess.Interfaces;
using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
   public class Role : IEntity
   {
      public Guid Id { get; set; }
      public string Name { get; set; }
      public List<User> Users { get; set; }
      public Role()
      {
         Users = new List<User>();
      }
   }
}
