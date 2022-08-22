using Business.DTO.Input;
using Business.DTO.Models.Characteristics.Gas;
using Business.DTO.Models.Characteristics.Quality;
using DataAccess.Entities;
using System.Collections.Generic;

namespace Business.BusinessModels.DataForCalculations
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
