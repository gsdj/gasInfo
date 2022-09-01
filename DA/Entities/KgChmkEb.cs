using DA.Interfaces;
using System;

namespace DA.Entities
{
   public class KgChmkEb : IGasEntity
   {
      public int Id { get; set; }
      public DateTime Date { get; set; }
      public decimal Consumption { get; set; }
   }
}
