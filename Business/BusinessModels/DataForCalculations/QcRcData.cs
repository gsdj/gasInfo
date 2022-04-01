using Business.DTO;

namespace Business.BusinessModels.DataForCalculations
{
   public class QcRcData
   {
      public DensityDTO WetGas;
      public DevicesKipDTO Kip;
   }
   public class QcRcDgData : QcRcData
   {
      public CharacteristicsDgDTO CharacteristicsDg;
   }
   public class QcRcKgData : QcRcData
   {
      public CharacteristicsKgDTO CharacteristicsKg;
   }
}
