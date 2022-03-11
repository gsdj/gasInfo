using Business.DTO;
using Business.Interfaces.Calculations;

namespace Business.Interfaces
{
   public interface IUnitOfCalc
   {
      public ICalculation<DensityDTO> WetGas { get; }
      public ICalculation<QualityDTO> Quality { get; }
      public ICalculation<ChartMonthDTO> ChartMonth { get; }
      public ICalculation<ChartYearDTO> ChartYear { get; }
      public ICalculation<ConsumptionKgDTO> ConsumptionKg { get; }
      public ICalculation<ConsumptionDgDTO> ConsumptionDg { get; }
      public ICalculation<ConsumptionDgPgDTO> ConsumptionDgPg { get; }
      public ICalculation<EbChmkDTO> EbChmk { get; }
      public ICalculation<OutputKgDTO> OutputKg { get; }
      public ICalculation<ReportKgDTO> ReportKg { get; }
      public ICalcCharacteristicsDg CharacteristicsDg { get; }
      public ICalcCharacteristicsKg CharacteristicsKg { get; }
      public ICalcCharacteristicsSteam CharacteristicsSteam { get; }
      public ICalcDgPgChmkEb DgPgChmkEb { get; }
      public ICalcProduction Production { get; }
      public ICalcTec Tec { get; }
      public ICalcInfoSheet InfoSheet { get; }
   }
}
