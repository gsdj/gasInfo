using Business.DTO.Models.General;

namespace Business.DTO.Models.Characteristics.Gas
{
   public class CharacteristicsDG : Entity
   {
      public CharacteristicsDG()
      {
         Kc1 = new GasCharacteristics();
         Kc2 = new GasCharacteristics();
         AVG = new GasCharacteristics();
      }
      public GasCharacteristics Kc1 { get; set; }
      public GasCharacteristics Kc2 { get; set; }
      public GasCharacteristics AVG { get; set; }
   }
}
