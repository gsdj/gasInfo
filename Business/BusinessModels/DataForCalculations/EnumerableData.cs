using Business.DTO;
using Business.DTO.Characteristics;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessModels.DataForCalculations
{
   public abstract class EnumerableData
   {
   }
   public class QualityEnumData : EnumerableData
   {
      public IEnumerable<QualityAll> Qualities;
      public IEnumerable<CharacteristicsKgDTO> Kg;
   }

   public class ChartEnumData : EnumerableData
   {
      public IEnumerable<ProductionDTO> Production;
      public IEnumerable<CharacteristicsKgDTO> CharacteristicsKg;
      public IEnumerable<QualityDTO> Quality;
      public IEnumerable<OutputKgDTO> OutputKg;
      public IEnumerable<ConsumptionKgDTO> ConsKg;
      public IEnumerable<AsdueDTO> Asdue;
      public IEnumerable<KgChmkEbDTO> KgChmkEb;
   }
   public class GasDensityEnumData : EnumerableData
   {
      public IEnumerable<PressureDTO> Pressure;
      public IEnumerable<CharacteristicsKgDTO> CharacteristicsKg;
      public IEnumerable<CharacteristicsDgDTO> CharacteristicsDg;
      public IEnumerable<DevicesKipDTO> Kip;
      public Dictionary<int, SteamCharacteristicsDTO> Steam;
   }
   public class ConsumptionKgEnumData : EnumerableData
   {
      public IEnumerable<DensityDTO> WetGas;
      public IEnumerable<DevicesKipDTO> Kip;
      public IEnumerable<CharacteristicsKgDTO> CharacteristicsKg;
      public Dictionary<int, SteamCharacteristicsDTO> Steam;
   }
   public class ConsumptionDgEnumData : EnumerableData
   {
      public IEnumerable<DensityDTO> WetGas;
      public IEnumerable<DevicesKipDTO> Kip;
      public IEnumerable<CharacteristicsDgDTO> CharacteristicsDg;
      public Dictionary<int, SteamCharacteristicsDTO> Steam;
   }
   public class ConsumptionDgPgEnumData : EnumerableData
   {
      public IEnumerable<DensityDTO> WetGas;
      public IEnumerable<DevicesKipDTO> Kip;
      public IEnumerable<ProductionDTO> Production;
      public IEnumerable<CharacteristicsDgDTO> CharacteristicsDg;
      public IEnumerable<PressureDTO> Pressure;
      public Dictionary<int, SteamCharacteristicsDTO> Steam;
   }
   public class EbChmkEnumData : EnumerableData
   {
      public IEnumerable<ProductionDTO> Production;
      public IEnumerable<DgPgChmkEbDTO> DgPgChmkEb;
   }
   public class OutputKgEnumData : EnumerableData
   {
      public IEnumerable<DensityDTO> WetGas;
      public IEnumerable<ProductionDTO> Production;
      public IEnumerable<DevicesKipDTO> Kip;
      public IEnumerable<CharacteristicsKgDTO> CharacteristicsKg;
      public Dictionary<int, SteamCharacteristicsDTO> Steam;
   }
   public class ReportKgEnumData : EnumerableData
   {
      public IEnumerable<ProductionDTO> Production;
      public IEnumerable<ConsumptionKgDTO> ConsKg;
      public IEnumerable<DevicesKipDTO> Kip;
      public IEnumerable<CharacteristicsKgDTO> CharacteristicsKg;
      public IEnumerable<OutputKgDTO> OutputKg;
      public IEnumerable<TecDTO> Tec;
   }
}
