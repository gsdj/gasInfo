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
      public UnitOfCalc (ICalculation<DensityDTO> wetGas, ICalculation<QualityDTO> qual, ICalculation<ChartMonthDTO> chartMonth, 
                           ICalculation<ChartYearDTO> chartYear, ICalculation<ConsumptionKgDTO> consKg, ICalculation<ConsumptionDgDTO> consDg,
                           ICalculation<ConsumptionDgPgDTO> consDgPg, ICalculation<EbChmkDTO> ebChmk, ICalculation<OutputKgDTO> outputKg,
                           ICalculation<ReportKgDTO> reportKg, ICalcCharacteristicsDg charDg, ICalcCharacteristicsKg charKg,
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
      public ICalculation<DensityDTO> WetGas { get; private set; }
      public ICalculation<QualityDTO> Quality { get; private set; }
      public ICalculation<ChartMonthDTO> ChartMonth { get; private set; }
      public ICalculation<ChartYearDTO> ChartYear { get; private set; }
      public ICalculation<ConsumptionKgDTO> ConsumptionKg { get; private set; }
      public ICalculation<ConsumptionDgDTO> ConsumptionDg { get; private set; }
      public ICalculation<ConsumptionDgPgDTO> ConsumptionDgPg { get; private set; }
      public ICalculation<EbChmkDTO> EbChmk { get; private set; }
      public ICalculation<OutputKgDTO> OutputKg { get; private set; }
      public ICalculation<ReportKgDTO> ReportKg { get; private set; }
      public ICalcCharacteristicsDg CharacteristicsDg { get; private set; }
      public ICalcCharacteristicsKg CharacteristicsKg { get; private set; }
      public ICalcCharacteristicsSteam CharacteristicsSteam { get; private set; }
      public ICalcDgPgChmkEb DgPgChmkEb { get; private set; }
      public ICalcProduction Production { get; private set; }
      public ICalcTec Tec { get; private set; }
      public ICalcInfoSheet InfoSheet { get; private set; }
   }
}
