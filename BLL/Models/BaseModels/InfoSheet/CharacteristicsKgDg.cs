using BLL.Models.BaseModels.Characteristics.Gas;

namespace BLL.Models.BaseModels.InfoSheet
{
   public class CharacteristicsKgDg
   {
      public CharacteristicsKgDg()
      {
         CharacteristicsDG = new GasCharacteristics();
         CharacteristicsKGKc1 = new GasCharacteristics();
         CharacteristicsKGKc2 = new GasCharacteristics();
      }
      public GasCharacteristics CharacteristicsDG { get; set; }
      public GasCharacteristics CharacteristicsKGKc1 { get; set; }
      public GasCharacteristics CharacteristicsKGKc2 { get; set; }
   }
}
