using DA.Interfaces;
using System;

namespace DA.Entities
{
   public class Asdue : IGasEntity
   {
      public Guid Id { get; set; }
      public DateTime Date { get; set; }
      public decimal TecNorth { get; set; }
      public decimal TecSouth { get; set; }
      public decimal Gps2Gss1 { get; set; }
      public decimal Gps2Gss2 { get; set; }
      public decimal NaturalGasQn { get; set; }
      public decimal OutPkg { get; set; }
   }
}
