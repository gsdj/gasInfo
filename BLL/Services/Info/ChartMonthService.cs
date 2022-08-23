using BLL.DataHelpers;
using BLL.DTO.Charts;
using BLL.DTO.Input;
using BLL.Interfaces;
using BLL.Interfaces.Services.Info;
using DA.Interfaces;
using System;
using System.Collections.Generic;

namespace BLL.Services.Info
{
   public class ChartMonthService : IChartMonthService
   {
      private IUnitOfWork db;
      private IUnitOfCalc Calc;
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
         var charKg = db.CharacteristicsKg.GetPerMonth(Date.Year, Date.Month);
         var charKgC = Calc.CharacteristicsKg.CalcEntities(charKg);
         var charDgC = Calc.CharacteristicsDg.CalcEntities(db.CharacteristicsDg.GetPerMonth(Date.Year, Date.Month));
         var KgChmkEb = db.KgChmkEb.GetPerMonth(Date.Year, Date.Month);
         var quality = db.Quality.GetPerMonth(Date.Year, Date.Month);
         var pressure = Pressure.GetItemsByMonth(Date);
         var kip = DevicesKip.GetItemsByMonth(Date);
         var asdue = Asdue.GetItemsByMonth(Date);
         var cbs = db.AmmountCb.GetPerMonth(Date.Year, Date.Month);

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
   }
}
