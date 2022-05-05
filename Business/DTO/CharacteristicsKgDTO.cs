using Business.DTO.Characteristics.CharacteristicsGas;
using System;

namespace Business.DTO
{
   public class CharacteristicsKgDTO
   {
      public CharacteristicsKgDTO()
      {
         Kc1 = new CharacteristicsKG();
         Kc2 = new CharacteristicsKG();
      }
      public DateTime Date { get; set; }
      public CharacteristicsKG Kc1 { get; set; }
      public CharacteristicsKG Kc2 { get; set; }
   }
}
