using BLL.DataHelpers;
using BLL.DTO.Charts;
using BLL.Interfaces;
using BLL.Interfaces.Services.Info;
using BLL.Interfaces.Services.Input;
using DA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services.Info
{
   public class ChartService : IChartService
   {
      private IUnitOfWork db;
      private IUnitOfCalc Calc;
      private IDevicesKipService DevicesKip;
      private IPressureService Pressure;
      private IAsdueService Asdue;
      public ChartService(IUnitOfWork uof, IUnitOfCalc calc, IDevicesKipService kip, IPressureService pressure, IAsdueService asd)
      {
         db = uof;
         Calc = calc;
         DevicesKip = kip;
         Pressure = pressure;
         Asdue = asd;
      }

      public IEnumerable<ChartMonthDTO> GasOutputPerMonth(DateTime Date)
      {
         var charKg = db.CharacteristicsKg.GetPerMonth(Date.Year, Date.Month).ToList();
         var charKgC = Calc.CharacteristicsKg.CalcEntities(charKg);
         var charDgC = Calc.CharacteristicsDg.CalcEntities(db.CharacteristicsDg.GetPerMonth(Date.Year, Date.Month));
         var KgChmkEb = db.KgChmkEb.GetPerMonth(Date.Year, Date.Month).ToList();
         var quality = db.Quality.GetPerMonth(Date.Year, Date.Month).ToList();
         var pressure = Pressure.GetItemsByMonth(Date);
         var kip = DevicesKip.GetItemsByMonth(Date);
         var asdue = Asdue.GetItemsByMonth(Date);
         var cbs = db.AmmountCb.GetPerMonth(Date.Year, Date.Month).ToList();

         var qualities = Calc.Quality.CalcEntities(quality, charKg);

         var chartData = new ChartEnumData
         {
            AmmountCbs = cbs,
            Asdue = asdue,
            CharacteristicsDg = charDgC,
            CharacteristicsKg = charKgC,
            KgChmkEb = KgChmkEb,
            Kip = kip,
            Pressure = pressure,
            Quality = qualities,
         };

         var chartMonth = Calc.ChartMonth.CalcEntities(chartData);
         return chartMonth;

      }

      public IEnumerable<ChartYearDTO> GasYearlyComparison(DateTime Date)
      {
         int Year = Date.Year;

         var charKg = db.CharacteristicsKg.GetPerYear(Date.Year).ToList();
         var charKgC = Calc.CharacteristicsKg.CalcEntities(charKg);
         var charDgC = Calc.CharacteristicsDg.CalcEntities(db.CharacteristicsDg.GetPerYear(Date.Year));
         var KgChmkEb = db.KgChmkEb.GetPerYear(Date.Year).ToList();
         var quality = db.Quality.GetPerYear(Date.Year).ToList();
         var pressure = Pressure.GetItemsByYear(Date.Year);
         var kip = DevicesKip.GetItemsByYear(Date.Year);
         var asdue = Asdue.GetItemsByYear(Date.Year);
         var cbs = db.AmmountCb.GetPerYear(Date.Year).ToList();

         var qualities = Calc.Quality.CalcEntities(quality, charKg);

         var chartData = new ChartEnumData
         {
            AmmountCbs = cbs,
            Asdue = asdue,
            CharacteristicsDg = charDgC,
            CharacteristicsKg = charKgC,
            KgChmkEb = KgChmkEb,
            Kip = kip,
            Pressure = pressure,
            Quality = qualities,
         };

         var chartYear = Calc.ChartYear.CalcEntities(chartData);
         return chartYear;
      }
   }
}
