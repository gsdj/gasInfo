using DA.Entities.Characteristics;
using DA.Interfaces;
using System;

namespace DA.Entities
{
   public class CharacteristicsKgAll : IGasEntity
   {
      public int Id { get; set; }
      public DateTime Date { get; set; }
      public KG Kc1 { get; set; }
      public KG Kc2 { get; set; }
   }
}
