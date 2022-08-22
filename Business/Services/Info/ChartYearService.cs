using Business.BusinessModels.DataForCalculations;
using Business.DTO.Charts;
using Business.DTO.Input;
using Business.Interfaces;
using Business.Interfaces.Services.Info;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;

namespace Business.Services.Info
{
   public class ChartYearService : IChartYearService
   {
      private IUnitOfWork db;
      private IUnitOfCalc Calc;
      private IYearable<DevicesKipDTO> DevicesKip;
      private IYearable<PressureDTO> Pressure;
      private IYearable<AsdueDTO> Asdue;
      public ChartYearService(IUnitOfWork uof, IUnitOfCalc calc, IYearable<DevicesKipDTO> kip, IYearable<PressureDTO> pressure, IYearable<AsdueDTO> asd)
      {
         db = uof;
         Calc = calc;
         DevicesKip = kip;
         Pressure = pressure;
         Asdue = asd;
      }
      public IEnumerable<ChartYearDTO> GetItemsByNowYear()
      {
         int Year = DateTime.Now.Year;
         return GetAllItems(Year);
      }

      public IEnumerable<ChartYearDTO> GetItemsByYear(int Year)
      {
         return GetAllItems(Year);
      }
      private IEnumerable<ChartYearDTO> GetAllItems(int Year)
      {
         var charKg = db.CharacteristicsKg.GetPerYear(Year);
         var charKgC = Calc.CharacteristicsKg.CalcEntities(charKg);
         var charDgC = Calc.CharacteristicsDg.CalcEntities(db.CharacteristicsDg.GetPerYear(Year));
         var KgChmkEb = db.KgChmkEb.GetPerYear(Year);
         var quality = db.Quality.GetPerYear(Year);
         var pressure = Pressure.GetItemsByYear(Year);
         var kip = DevicesKip.GetItemsByYear(Year);
         var asdue = Asdue.GetItemsByYear(Year);
         var cbs = db.AmmountCb.GetPerYear(Year);

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
