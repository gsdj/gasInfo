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
   public abstract class Data
   {
   }
   public class QualityData : Data
   {
      public QualityAll Qualities;
      public CharacteristicsKgDTO Kg;
   }
   public class ChartData : Data
   {
      public ProductionDTO Production;
      public CharacteristicsKgDTO CharacteristicsKg;
      public QualityDTO Quality;
      public OutputKgDTO OutputKg;
      public ConsumptionKgDTO ConsKg; 
      public AsdueDTO Asdue;
      public KgChmkEbDTO KgChmkEb;
   }
   public class GasDensityData : Data
   {
      public PressureDTO Pressure;
      public CharacteristicsKgDTO CharacteristicsKg;
      public CharacteristicsDgDTO CharacteristicsDg;
      public DevicesKipDTO Kip;
      public Dictionary<int, SteamCharacteristicsDTO> Steam;
   }
   public class ConsumptionKgData : Data
   {
      public DensityDTO WetGas;
      public DevicesKipDTO Kip;
      public CharacteristicsKgDTO CharacteristicsKg;
      public Dictionary<int, SteamCharacteristicsDTO> Steam;
   }
   public class ConsumptionDgData : Data
   {
      public DensityDTO WetGas;
      public DevicesKipDTO Kip;
      public CharacteristicsDgDTO CharacteristicsDg;
      public Dictionary<int, SteamCharacteristicsDTO> Steam;
   }
   public class ConsumptionDgPgData : Data
   {
      public DensityDTO WetGas;
      public DevicesKipDTO Kip;
      public ProductionDTO Production;
      public CharacteristicsDgDTO CharacteristicsDg;
      public PressureDTO Pressure;
      public Dictionary<int, SteamCharacteristicsDTO> Steam;
   }
   public class EbChmkData : Data
   {
      public IEnumerable<ProductionDTO> Production;
      public DgPgChmkEbDTO DgPgChmkEb;
   }
   public class OutputKgData : Data
   {
      public DensityDTO WetGas;
      public ProductionDTO Production;
      public DevicesKipDTO Kip;
      public CharacteristicsKgDTO CharacteristicsKg;
      public Dictionary<int, SteamCharacteristicsDTO> Steam;
   }
   public class ReportKgData : Data
   {
      public ProductionDTO Production;
      public ConsumptionKgDTO ConsKg;
      public DevicesKipDTO Kip;
      public CharacteristicsKgDTO CharacteristicsKg;
      public OutputKgDTO OutputKg;
      public TecDTO Tec;
   }
}
