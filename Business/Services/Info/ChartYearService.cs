using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.Interfaces;
using Business.Interfaces.Services;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;

namespace Business.Services.Info
{
   public class ChartYearService : IChartYearService
   {
      IUnitOfWork db;
      IUnitOfCalc Calc;
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
         var prod = Calc.Production.CalcEntities(db.AmmountCb.GetPerYear(Year));
         var charKg = Calc.CharacteristicsKg.CalcEntities(db.CharacteristicsKg.GetPerYear(Year));
         var charDg = Calc.CharacteristicsDg.CalcEntities(db.CharacteristicsDg.GetPerYear(Year));
         var KgChmkEb = db.KgChmkEb.GetPerYear(Year);
         var quality = db.Quality.GetPerYear(Year);
         var pressure = Pressure.GetItemsByYear(Year);
         var kip = DevicesKip.GetItemsByYear(Year);
         var asdue = Asdue.GetItemsByYear(Year);

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
            WetGas = wetGas,
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
         var chartYear = Calc.ChartYear.CalcEntities(chartData);
         return chartYear;
      }
   }
}
