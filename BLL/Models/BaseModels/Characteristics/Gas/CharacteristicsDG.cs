using BLL.Models.BaseModels.General;

namespace BLL.Models.BaseModels.Characteristics.Gas
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
