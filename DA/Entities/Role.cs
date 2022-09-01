using DA.Interfaces;
using System;
using System.Collections.Generic;

namespace DA.Entities
{
   public class Role : IEntity
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public List<User> Users { get; set; }
      public Role()
      {
         Users = new List<User>();
      }
   }
}
