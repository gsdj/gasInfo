using System;

namespace DA.Interfaces
{
   public interface IGasEntity : IEntity
   {
      DateTime Date { get; set; }
   }
}
