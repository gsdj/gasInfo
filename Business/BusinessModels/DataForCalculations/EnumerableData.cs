using Business.DTO;
using DataAccess.Entities;
using System.Collections.Generic;

namespace Business.BusinessModels.DataForCalculations
{
   public class EnumerableData
   {
      public IEnumerable<PressureDTO> Pressure;
      public IEnumerable<CharacteristicsKgDTO> CharacteristicsKg;
      public IEnumerable<CharacteristicsDgDTO> CharacteristicsDg;
      public IEnumerable<DevicesKipDTO> Kip;
   }
   public class ChartEnumData : EnumerableData
   {
      public IEnumerable<AmmountCb> AmmountCbs;
      public IEnumerable<QualityDTO> Quality;
      public IEnumerable<OutputKgDTO> OutputKg;
      public IEnumerable<ConsumptionKgDTO> ConsKg;
      public IEnumerable<AsdueDTO> Asdue;
      public IEnumerable<KgChmkEbDTO> KgChmkEb;
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
