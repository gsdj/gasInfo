using System;

namespace DataAccess.Entities
{
   public class User : IEntity
   {
      public Guid Id { get; set; }
      public string Login { get; set; }
      public string Password { get; set; }
      public Guid? RoleId { get; set; }
      public Role Role { get; set; }
   }
}
