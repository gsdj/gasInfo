using Business.DTO;
using Business.DTO.Models.Characteristics.Gas;

namespace Business.BusinessModels.DataForCalculations
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
