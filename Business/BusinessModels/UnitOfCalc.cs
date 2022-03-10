using Business.DTO;
using Business.Interfaces;
using Business.Interfaces.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessModels
{
   public class UnitOfCalc : IUnitOfCalc
   {
      public UnitOfCalc (ICalculations<DensityDTO> wetGas, ICalculations<QualityDTO> qual, ICalculations<ChartMonthDTO> chartMonth, 
                           ICalculations<ChartYearDTO> chartYear, ICalculations<ConsumptionKgDTO> consKg, ICalculations<ConsumptionDgDTO> consDg,
                           ICalculations<ConsumptionDgPgDTO> consDgPg, ICalculations<EbChmkDTO> ebChmk, ICalculations<OutputKgDTO> outputKg,
                           ICalculations<ReportKgDTO> reportKg, ICalcCharacteristicsDg charDg, ICalcCharacteristicsKg charKg,
                           ICalcCharacteristicsSteam steam, ICalcDgPgChmkEb dgpgChmk, ICalcProduction prod,
                           ICalcTec tec, ICalcInfoSheet info)
      {
         WetGas = wetGas;
         Quality = qual;
         ChartMonth = chartMonth;
         ChartYear = chartYear;
         ConsumptionKg = consKg;
         ConsumptionDg = consDg;
         ConsumptionDgPg = consDgPg;
         EbChmk = ebChmk;
         OutputKg = outputKg;
         ReportKg = reportKg;
         CharacteristicsKg = charKg;
         CharacteristicsDg = charDg;
         CharacteristicsSteam = steam;
         DgPgChmkEb = dgpgChmk;
         Production = prod;
         Tec = tec;
         InfoSheet = info;
      }
      public ICalculations<DensityDTO> WetGas { get; private set; }
      public ICalculations<QualityDTO> Quality { get; private set; }
      public ICalculations<ChartMonthDTO> ChartMonth { get; private set; }
      public ICalculations<ChartYearDTO> ChartYear { get; private set; }
      public ICalculations<ConsumptionKgDTO> ConsumptionKg { get; private set; }
      public ICalculations<ConsumptionDgDTO> ConsumptionDg { get; private set; }
      public ICalculations<ConsumptionDgPgDTO> ConsumptionDgPg { get; private set; }
      public ICalculations<EbChmkDTO> EbChmk { get; private set; }
      public ICalculations<OutputKgDTO> OutputKg { get; private set; }
      public ICalculations<ReportKgDTO> ReportKg { get; private set; }
      public ICalcCharacteristicsDg CharacteristicsDg { get; private set; }
      public ICalcCharacteristicsKg CharacteristicsKg { get; private set; }
      public ICalcCharacteristicsSteam CharacteristicsSteam { get; private set; }
      public ICalcDgPgChmkEb DgPgChmkEb { get; private set; }
      public ICalcProduction Production { get; private set; }
      public ICalcTec Tec { get; private set; }
      public ICalcInfoSheet InfoSheet { get; private set; }
   }
}
