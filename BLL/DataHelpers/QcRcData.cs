using BLL.DTO;
using BLL.DTO.Input;
using BLL.Models.BaseModels.Characteristics.Gas;

namespace BLL.DataHelpers
{
   public class QcRcData
   {
      public DensityDTO WetGas;
      public DevicesKipDTO Kip;
   }
   public class QcRcDgData : QcRcData
   {
      public CharacteristicsDG CharacteristicsDg;
   }
   public class QcRcKgData : QcRcData
   {
      public CharacteristicsKG CharacteristicsKg;
   }
}
