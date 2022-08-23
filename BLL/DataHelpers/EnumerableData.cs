using BLL.DTO.Input;
using BLL.Models.BaseModels.Characteristics.Gas;
using BLL.Models.BaseModels.Characteristics.Quality;
using DA.Entities;
using System.Collections.Generic;

namespace BLL.DataHelpers
{
   public class EnumerableData
   {
      public IEnumerable<PressureDTO> Pressure;
      public IEnumerable<CharacteristicsKG> CharacteristicsKg;
      public IEnumerable<CharacteristicsDG> CharacteristicsDg;
      public IEnumerable<DevicesKipDTO> Kip;
   }
   public class ChartEnumData : EnumerableData
   {
      public IEnumerable<AmmountCb> AmmountCbs;
      public IEnumerable<QualityCharacteristics> Quality;
      public IEnumerable<AsdueDTO> Asdue;
      public IEnumerable<KgChmkEb> KgChmkEb;
   }
   public class OutputKgEnumData : EnumerableData
   {
      public IEnumerable<AmmountCb> AmmountCbs;
   }
   public class ReportKgEnumData : EnumerableData
   {
      public IEnumerable<AmmountCb> AmmountCbs;
      public IEnumerable<TecDTO> Tec;
   }
}
