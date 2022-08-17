using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.Interfaces;
using Business.Interfaces.Services.Info;
using DataAccess.Interfaces;
using System;
using System.Linq;

namespace Business.Services.Info
{
   public class InfoSheetService : IInfoSheetService
   {
      private IUnitOfWork db;
      private IUnitOfCalc Calc;
      private IMonthable<DevicesKipDTO> DevicesKip;
      private IMonthable<PressureDTO> Pressure;
      private IMonthable<AsdueDTO> Asdue;
      public InfoSheetService(IUnitOfWork uof, IUnitOfCalc calc, IMonthable<DevicesKipDTO> kip, IMonthable<PressureDTO> pressure, IMonthable<AsdueDTO> asd)
      {
         db = uof;
         Calc = calc;
         DevicesKip = kip;
         Pressure = pressure;
         Asdue = asd;
      }
      public InfoSheetDTO GetItemByDate(DateTime Date)
      {
         var charKg = db.CharacteristicsKg.GetPerMonth(Date.Year, Date.Month);
         var charKgC = Calc.CharacteristicsKg.CalcEntities(charKg);
         var charDgC = Calc.CharacteristicsDg.CalcEntities(db.CharacteristicsDg.GetPerMonth(Date.Year, Date.Month));
         var prod = Calc.Production.CalcEntities(db.AmmountCb.GetPerMonth(Date.Year, Date.Month));
         var pressure = Pressure.GetItemsByMonth(Date);
         var kip = DevicesKip.GetItemsByMonth(Date);
         var tec = Calc.Tec.CalcEntities(db.Tec.GetPerMonth(Date.Year, Date.Month));
         var asdue = Asdue.GetItemsByMonth(Date);
         var KgChmkEb = db.KgChmkEb.GetPerMonth(Date.Year, Date.Month);
         var quality = db.Quality.GetPerMonth(Date.Year, Date.Month);
         var cbs = db.AmmountCb.GetPerMonth(Date.Year, Date.Month);

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
