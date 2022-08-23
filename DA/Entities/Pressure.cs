using DA.Interfaces;
using System;

namespace DA.Entities
{
   public class Pressure : IGasEntity
   {
      public Guid Id { get; set; }
      public DateTime Date { get; set; }
      public decimal Value { get; set; }
   }
}
