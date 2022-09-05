using DA.Interfaces;
using System;

namespace DA.Entities
{
   public class AmmountCb : CokeBattery<int>, IGasEntity
   {
      public int Id { get; set; }
      public DateTime Date { get; set; }
      public int OutputMultipliersId { get; set; }
      public virtual OutputMultipliers OutputMultipliers { get; set; }
   }
}
