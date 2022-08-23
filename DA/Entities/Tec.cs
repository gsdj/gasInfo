using DA.Interfaces;
using System;

namespace DA.Entities
{
   public class Tec : IGasEntity
   {
      public Guid Id { get; set; }
      public DateTime Date { get; set; }
      public decimal Chmk { get; set; }
      public decimal TecNorth { get; set; }
      public decimal TecSouth { get; set; }
   }
}
