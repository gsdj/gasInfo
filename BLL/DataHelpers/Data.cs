using BLL.DTO.Input;
using BLL.Models.BaseModels.Characteristics.Gas;
using BLL.Models.BaseModels.Characteristics.Quality;
using DA.Entities;

namespace BLL.DataHelpers
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
