using BLL.DTO;
using BLL.DTO.Charts;
using BLL.DTO.Consumption;
using BLL.Interfaces.Calculations;
using BLL.Interfaces.Calculations.Characteristics;

namespace BLL.Interfaces
{
   public interface IUnitOfCalc
   {
      public ICalculations<DensityDTO> WetGas { get; }
      public ICalcQuality Quality { get; }
      public ICalculations<ChartMonthDTO> ChartMonth { get; }
      public ICalculations<ChartYearDTO> ChartYear { get; }
      public ICalculations<ConsumptionKgDTO> ConsumptionKg { get; }
      public ICalculations<ConsumptionDgDTO> ConsumptionDg { get; }
      public ICalculations<ConsumptionDgPgDTO> ConsumptionDgPg { get; }
      public ICalcEbChmk EbChmk { get; }
      public ICalculations<OutputKgDTO> OutputKg { get; }
      public ICalculations<ReportKgDTO> ReportKg { get; }
      public ICalcCharacteristicsDg CharacteristicsDg { get; }
      public ICalcCharacteristicsKg CharacteristicsKg { get; }
      public ICalcProduction Production { get; }
      public ICalcTec Tec { get; }
      public ICalcInfoSheet InfoSheet { get; }
   }
}
