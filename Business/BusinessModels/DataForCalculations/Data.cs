using Business.DTO;
using Business.DTO.Models.Characteristics.Gas;
using Business.DTO.Models.Characteristics.Quality;
using DataAccess.Entities;

namespace Business.BusinessModels.DataForCalculations
{
   public class Data
   {
      public PressureDTO Pressure;
      public CharacteristicsKG CharacteristicsKg;
      public CharacteristicsDG CharacteristicsDg;
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
      public QualityCharacteristics Quality;
      public AsdueDTO Asdue;
      public KgChmkEb KgChmkEb;
   }
}
