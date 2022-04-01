using Business.DTO;
using DataAccess.Entities;

namespace Business.BusinessModels.DataForCalculations
{
   public class Data
   {
      public PressureDTO Pressure;
      public CharacteristicsKgDTO CharacteristicsKg;
      public CharacteristicsDgDTO CharacteristicsDg;
      public DevicesKipDTO Kip;
   }
   public class OutputKgData : Data
   {
      public AmmountCb AmmountCb;
   }
   public class ReportKgData : Data
   {
      public AmmountCb AmmountCb;
      public TecDTO Tec; 
   }
   public class ChartData : Data
   {
      public AmmountCb AmmountCb;
      public QualityDTO Quality;
      public AsdueDTO Asdue;
      public KgChmkEb KgChmkEb;
   }
}
