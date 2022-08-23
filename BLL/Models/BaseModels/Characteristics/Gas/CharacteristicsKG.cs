using BLL.Models.BaseModels.General;

namespace BLL.Models.BaseModels.Characteristics.Gas
{
   public class CharacteristicsKG : Entity
   {
      public CharacteristicsKG()
      {
         Kc1 = new GasCharacteristics();
         Kc2 = new GasCharacteristics();
      }
      public GasCharacteristics Kc1 { get; set; }
      public GasCharacteristics Kc2 { get; set; }
   }
}
