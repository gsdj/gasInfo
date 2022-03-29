using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.Interfaces;
using Business.Interfaces.Services;
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
         var charKg = Calc.CharacteristicsKg.CalcEntities(db.CharacteristicsKg.GetPerMonth(Date.Year, Date.Month));
         var charDg = Calc.CharacteristicsDg.CalcEntities(db.CharacteristicsDg.GetPerMonth(Date.Year, Date.Month));
         var prod = Calc.Production.CalcEntities(db.AmmountCb.GetPerMonth(Date.Year, Date.Month));
         var pressure = Pressure.GetItemsByMonth(Date);
         var kip = DevicesKip.GetItemsByMonth(Date);
         var tec = Calc.Tec.CalcEntities(db.Tec.GetPerMonth(Date.Year, Date.Month));
         var asdue = Asdue.GetItemsByMonth(Date);
         var KgChmkEb = db.KgChmkEb.GetPerMonth(Date.Year, Date.Month);
         var quality = db.Quality.GetPerMonth(Date.Year, Date.Month);

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

         var reportKgData = new ReportKgEnumData
         {
            CharacteristicsKg = charKg,
            ConsKg = consKg,
            Kip = kip,
            OutputKg = outputKg,
            Production = prod,
            Tec = tec,
         };
         var reportKg = Calc.ReportKg.CalcEntities(reportKgData);

         var consDgData = new ConsumptionDgEnumData
         {
            CharacteristicsDg = charDg,
            Kip = kip,
            WetGas = wetGas,
         };
         var consDg = Calc.ConsumptionDg.CalcEntities(consDgData);

         var consDgPgData = new ConsumptionDgPgEnumData
         {
            CharacteristicsDg = charDg,
            Kip = kip,
            Pressure = pressure,
            Production = prod,
            WetGas = wetGas,
         };
         var consDgPg = Calc.ConsumptionDgPg.CalcEntities(consDgPgData);

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

         var infoSheetData = new InfoSheetData
         {
            Date = Date,
            AsdueDTO = asdue.SingleOrDefault(p => p.Date == Date),
            CharacteristicsDg = charDg.SingleOrDefault(p => p.Date == Date),
            CharacteristicsKg = charKg.SingleOrDefault(p => p.Date == Date),
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
