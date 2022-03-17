using Business.DTO;
using Business.Interfaces.Calculations;

namespace Business.Interfaces
{
   public interface IUnitOfCalc
   {
      public ICalculations<DensityDTO> WetGas { get; }
      public ICalculations<QualityDTO> Quality { get; }
      public ICalculations<ChartMonthDTO> ChartMonth { get; }
      public ICalculations<ChartYearDTO> ChartYear { get; }
      public ICalculations<ConsumptionKgDTO> ConsumptionKg { get; }
      public ICalculations<ConsumptionDgDTO> ConsumptionDg { get; }
      public ICalculations<ConsumptionDgPgDTO> ConsumptionDgPg { get; }
      public ICalculations<EbChmkDTO> EbChmk { get; }
      public ICalculations<OutputKgDTO> OutputKg { get; }
      public ICalculations<ReportKgDTO> ReportKg { get; }
      public ICalcCharacteristicsDg CharacteristicsDg { get; }
      public ICalcCharacteristicsKg CharacteristicsKg { get; }
      public ICalcDgPgChmkEb DgPgChmkEb { get; }
      public ICalcProduction Production { get; }
      public ICalcTec Tec { get; }
      public ICalcInfoSheet InfoSheet { get; }
   }
}
