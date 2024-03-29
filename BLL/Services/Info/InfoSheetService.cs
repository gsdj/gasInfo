﻿using BLL.DataHelpers;
using BLL.DTO;
using BLL.DTO.Input;
using BLL.Interfaces;
using BLL.Interfaces.Services.Info;
using BLL.Interfaces.Services.Input;
using DA.Interfaces;
using System;
using System.Linq;

namespace BLL.Services.Info
{
   public class InfoSheetService : IInfoSheetService
   {
      private IUnitOfWork db;
      private IUnitOfCalc Calc;
      private IDevicesKipService DevicesKip;
      private IPressureService Pressure;
      private IAsdueService Asdue;
      public InfoSheetService(IUnitOfWork uof, IUnitOfCalc calc, IDevicesKipService kip, IPressureService pressure, IAsdueService asd)
      {
         db = uof;
         Calc = calc;
         DevicesKip = kip;
         Pressure = pressure;
         Asdue = asd;
      }
      public InfoSheetDTO GetItemByDate(DateTime Date)
      {
         var charKg = db.CharacteristicsKg.GetPerMonth(Date.Year, Date.Month).ToList();
         var charKgC = Calc.CharacteristicsKg.CalcEntities(charKg);
         var charDgC = Calc.CharacteristicsDg.CalcEntities(db.CharacteristicsDg.GetPerMonth(Date.Year, Date.Month));
         var prod = Calc.Production.CalcEntities(db.AmmountCb.GetPerMonth(Date.Year, Date.Month).ToList());
         var pressure = Pressure.GetItemsByMonth(Date);
         var kip = DevicesKip.GetItemsByMonth(Date);
         var tec = Calc.Tec.CalcEntities(db.Tec.GetPerMonth(Date.Year, Date.Month));
         var asdue = Asdue.GetItemsByMonth(Date);
         var KgChmkEb = db.KgChmkEb.GetPerMonth(Date.Year, Date.Month).ToList();
         var quality = db.Quality.GetPerMonth(Date.Year, Date.Month).ToList();
         var cbs = db.AmmountCb.GetPerMonth(Date.Year, Date.Month).ToList();

         var qualities = Calc.Quality.CalcEntities(quality, charKg);

         var enumData = new EnumerableData
         {
            CharacteristicsKg = charKgC,
            Kip = kip,
            CharacteristicsDg = charDgC,
            Pressure = pressure,
         };
         var consKg = Calc.ConsumptionKg.CalcEntities(enumData);

         var outputKgData = new OutputKgEnumData
         {
            CharacteristicsKg = charKgC,
            Kip = kip,
            CharacteristicsDg = charDgC,
            Pressure = pressure,
            AmmountCbs = cbs,
         };
         var outputKg = Calc.OutputKg.CalcEntities(outputKgData);

         var reportKgData = new ReportKgEnumData
         {
            CharacteristicsKg = charKgC,
            Kip = kip,
            CharacteristicsDg = charDgC,
            Pressure = pressure,
            AmmountCbs = cbs,
            Tec = tec,
         };
         var reportKg = Calc.ReportKg.CalcEntities(reportKgData);

         var consDg = Calc.ConsumptionDg.CalcEntities(enumData);

         var consDgPg = Calc.ConsumptionDgPg.CalcEntities(outputKgData);

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

         var infoSheetData = new InfoSheetData
         {
            Date = Date,
            AsdueDTO = asdue.SingleOrDefault(p => p.Date == Date),
            CharacteristicsDg = charDgC.SingleOrDefault(p => p.Date == Date),
            CharacteristicsKg = charKgC.SingleOrDefault(p => p.Date == Date),
            ChartMonth = chartMonth.SingleOrDefault(p => p.Date == Date),
            ProductionDTOs = prod,
            ConsumptionKgDTOs = consKg,
            ConsumptionDgDTOs = consDg,
            ConsumptionDgPgDTOs = consDgPg,
            OutputKgDTOs = outputKg,
            ReportKgDTOs = reportKg,
         };

         var infoSheet = Calc.InfoSheet.CalcInfo(infoSheetData);

         return infoSheet;
      }
   }
}
