using DA.Entities.Characteristics;
using DA.Interfaces;
using System;

namespace DA.Entities
{
   public class CharacteristicsKgAll : IGasEntity
   {
      public CharacteristicsKgAll()
      {
         Kc1 = new KG();
         Kc2 = new KG();
      }
      public Guid Id { get; set; }
      public DateTime Date { get; set; }
      public KG Kc1 { get; set; }
      public KG Kc2 { get; set; }
   }
}
