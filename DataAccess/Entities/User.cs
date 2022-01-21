using System;

namespace DataAccess.Entities
{
   public class User
   {
      public Guid Guid { get; set; }
      public string Login { get; set; }
      public string Password { get; set; }
      public Guid? RoleGuid { get; set; }
      public Role Role { get; set; }
   }
}
