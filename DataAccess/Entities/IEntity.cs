using System;

namespace DataAccess.Entities
{
   public interface IEntity
   {
      Guid Id { get; set; }
   }
}
