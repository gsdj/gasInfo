using DA.Entities.Characteristics;
using DA.Interfaces;
using System;

namespace DA.Entities
{
   public class CharacteristicsDgAll : IGasEntity
   {
      //public CharacteristicsDgAll()
      //{
      //   Kc1 = new DG();
      //   Kc2 = new DG();
      //}
      public int Id { get; set; }
      public DateTime Date { get; set; }
      public DG Kc1 { get; set; }
      public DG Kc2 { get; set; }
   }
}
