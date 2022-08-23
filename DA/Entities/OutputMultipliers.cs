using DA.Interfaces;
using System;
using System.Collections.Generic;

namespace DA.Entities
{
   public class OutputMultipliers : CokeBattery<decimal>, IGasEntity
   {
      public Guid Id { get; set; }
      public DateTime Date { get; set; }
      public decimal Sv { get; set; }
      public decimal Fv { get; set; }
      public decimal Peka { get; set; }
      public ICollection<AmmountCb> AmmountCbs { get; }

      public OutputMultipliers()
      {
         AmmountCbs = new List<AmmountCb>();
      }
   }
}
