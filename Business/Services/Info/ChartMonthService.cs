using Business.BusinessModels;
using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.Interfaces;
using Business.Interfaces.Services;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services.Info
{
   public class ChartMonthService : IChartMonthService
   {
      IUnitOfWork db;
      IUnitOfCalc Calc;
      private IMonthable<DevicesKipDTO> DevicesKip;
      private IMonthable<PressureDTO> Pressure;
      private IMonthable<AsdueDTO> Asdue;
      public ChartMonthService(IUnitOfWork uof, IUnitOfCalc calc, IMonthable<DevicesKipDTO> kip, IMonthable<PressureDTO> pressure, IMonthable<AsdueDTO> asd)
      {
         db = uof;
         Calc = calc;
         DevicesKip = kip;
         Pressure = pressure;
         Asdue = asd;
      }
      public IEnumerable<ChartMonthDTO> GetItemsByMonth(DateTime Date)
      {
         return GetItemsByDate(Date);
      }

      public IEnumerable<ChartMonthDTO> GetItemsByNowMonth()
      {
         DateTime dateNow = DateTime.Now;
         return GetItemsByDate(dateNow);
      }

      private IEnumerable<ChartMonthDTO> GetItemsByDate(DateTime Date)
      {
         var prod = Calc.Production.CalcEntities(db.AmmountCb.GetPerMonth(Date.Year, Date.Month));
         var charKg = Calc.CharacteristicsKg.CalcEntities(db.CharacteristicsKg.GetPerMonth(Date.Year, Date.Month));
         var charDg = Calc.CharacteristicsDg.CalcEntities(db.CharacteristicsDg.GetPerMonth(Date.Year, Date.Month));
         var KgChmkEb = db.KgChmkEb.GetPerMonth(Date.Year, Date.Month);
         var quality = db.Quality.GetPerMonth(Date.Year, Date.Month);
         var pressure = Pressure.GetItemsByMonth(Date);
         var kip = DevicesKip.GetItemsByMonth(Date);
         var asdue = Asdue.GetItemsByMonth(Date);

         var qualityData = new QualityEnumData
         {
            Qualities = quality,
            Kg = charKg,
         };
         var qualities = Calc.Quality.CalcEntities(qualityData);

         var wetGasData = new GasDensityEnumData
         {
            CharacteristicsDg = charDg,
            CharacteristicsKg = charKg,
            Kip = kip,
            Pressure = pressure,
         };
         var wetGas = Calc.WetGas.CalcEntities(wetGasData);

         var consKgData = new ConsumptionKgEnumData
         {
            CharacteristicsKg = charKg,
            Kip = kip,
            //WetGas = wetGas,
         };
         var consKg = Calc.ConsumptionKg.CalcEntities(consKgData);

         var outputKgData = new OutputKgEnumData
         {
            WetGas = wetGas,
            CharacteristicsKg = charKg,
            Kip = kip,
            Production = prod,
         };
         var outputKg = Calc.OutputKg.CalcEntities(outputKgData);

         var chartData = new ChartEnumData
         {
            CharacteristicsKg = charKg,
            ConsKg = consKg,
            OutputKg = outputKg,
            Production = prod,
            Quality = qualities,
            KgChmkEb = KgChmkEb,
            Asdue = asdue,
         };
         var chartMonth = Calc.ChartMonth.CalcEntities(chartData);
         return chartMonth;

      }
   }
}
