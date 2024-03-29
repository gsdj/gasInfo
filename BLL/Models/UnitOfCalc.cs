﻿using BLL.DTO;
using BLL.DTO.Charts;
using BLL.DTO.Consumption;
using BLL.Interfaces;
using BLL.Interfaces.Calculations;
using BLL.Interfaces.Calculations.Characteristics;

namespace BLL.Models
{
   public class UnitOfCalc : IUnitOfCalc
   {
      public UnitOfCalc (ICalculations<DensityDTO> wetGas, ICalcQuality qual, ICalculations<ChartMonthDTO> chartMonth, 
                           ICalculations<ChartYearDTO> chartYear, ICalculations<ConsumptionKgDTO> consKg, ICalculations<ConsumptionDgDTO> consDg,
                           ICalculations<ConsumptionDgPgDTO> consDgPg, ICalcEbChmk ebChmk, ICalculations<OutputKgDTO> outputKg,
                           ICalculations<ReportKgDTO> reportKg, ICalcCharacteristicsDg charDg, ICalcCharacteristicsKg charKg,
                           ICalcProduction prod, ICalcTec tec, ICalcInfoSheet info)
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
         Production = prod;
         Tec = tec;
         InfoSheet = info;
      }
      public ICalculations<DensityDTO> WetGas { get; private set; }
      public ICalcQuality Quality { get; private set; }
      public ICalculations<ChartMonthDTO> ChartMonth { get; private set; }
      public ICalculations<ChartYearDTO> ChartYear { get; private set; }
      public ICalculations<ConsumptionKgDTO> ConsumptionKg { get; private set; }
      public ICalculations<ConsumptionDgDTO> ConsumptionDg { get; private set; }
      public ICalculations<ConsumptionDgPgDTO> ConsumptionDgPg { get; private set; }
      public ICalcEbChmk EbChmk { get; private set; }
      public ICalculations<OutputKgDTO> OutputKg { get; private set; }
      public ICalculations<ReportKgDTO> ReportKg { get; private set; }
      public ICalcCharacteristicsDg CharacteristicsDg { get; private set; }
      public ICalcCharacteristicsKg CharacteristicsKg { get; private set; }
      public ICalcProduction Production { get; private set; }
      public ICalcTec Tec { get; private set; }
      public ICalcInfoSheet InfoSheet { get; private set; }
   }
}
