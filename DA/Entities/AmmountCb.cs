using DA.Interfaces;
using System;

namespace DA.Entities
{
   public class AmmountCb : CokeBattery<int>, IGasEntity
   {
      public Guid Id { get; set; }
      public DateTime Date { get; set; }
      public Guid OutputMultipliersId { get; set; }
      public OutputMultipliers OutputMultipliers { get; set; }
   }
}
