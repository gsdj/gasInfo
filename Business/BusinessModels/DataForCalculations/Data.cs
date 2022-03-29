using Business.DTO;
using DataAccess.Entities;
using System.Collections.Generic;

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
      public KgChmkEb KgChmkEb;
   }
   public class GasDensityData : Data
   {
      public PressureDTO Pressure;
      public CharacteristicsKgDTO CharacteristicsKg;
      public CharacteristicsDgDTO CharacteristicsDg;
      public DevicesKipDTO Kip;
   }
   public class ConsumptionKgData : Data
   {
      public PressureDTO Pressure;
      public CharacteristicsKgDTO CharacteristicsKg;
      public CharacteristicsDgDTO CharacteristicsDg;
      public DevicesKipDTO Kip;
   }
   public class ConsumptionDgData : Data
   {
      public DensityDTO WetGas;
      public DevicesKipDTO Kip;
      public CharacteristicsDgDTO CharacteristicsDg;
   }
   public class ConsumptionDgPgData : Data
   {
      public DensityDTO WetGas;
      public DevicesKipDTO Kip;
      public ProductionDTO Production;
      public CharacteristicsDgDTO CharacteristicsDg;
      public PressureDTO Pressure;
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
