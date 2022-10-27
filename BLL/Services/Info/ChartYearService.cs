using BLL.DataHelpers;
using BLL.DTO.Charts;
using BLL.DTO.Input;
using BLL.Interfaces;
using BLL.Interfaces.Services.Info;
using BLL.Interfaces.Services.Input;
using DA.Interfaces;
using System;
using System.Collections.Generic;

namespace BLL.Services.Info
{
   public class ChartYearService : IChartYearService
   {
      private IUnitOfWork db;
      private IUnitOfCalc Calc;
      private IDevicesKipService DevicesKip;
      private IPressureService Pressure;
      private IAsdueService Asdue;
      public ChartYearService(IUnitOfWork uof, IUnitOfCalc calc, IDevicesKipService kip, IPressureService pressure, IAsdueService asd)
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
