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
      public ChartMonthService(IUnitOfWork uof, IUnitOfCalc calc, IMonthable<DevicesKipDTO> kip, IMonthable<PressureDTO> pressure)
      {
         db = uof;
         Calc = calc;
         DevicesKip = kip;
         Pressure = pressure;
      }
      public IEnumerable<ChartMonthDTO> GetItemsByMonth(DateTime Date)
      {
         DateTime fDate = new DateTime(Date.Year, Date.Month, 1);
         DateTime lDate = new DateTime(Date.Year, Date.Month, DateTime.DaysInMonth(Date.Year, Date.Month));
         
         throw new NotImplementedException();
      }

      public IEnumerable<ChartMonthDTO> GetItemsByNowMonth()
      {
         throw new NotImplementedException();
      }

      private IEnumerable<ChartMonthDTO> GetItemsByDate(DateTime Date)
      {
         var prod = Calc.Production.CalcEntities(db.AmmountCb.GetPerMonth(Date.Year, Date.Month));
         var charKg = Calc.CharacteristicsKg.CalcEntities(db.CharacteristicsKg.GetPerMonth(Date.Year, Date.Month));
         var charDg = Calc.CharacteristicsDg.CalcEntities(db.CharacteristicsDg.GetPerMonth(Date.Year, Date.Month));
         var steam = Calc.CharacteristicsSteam.CalcEntities(db.SteamCharacteristics.GetAll());
         var KgChmkEb = db.KgChmkEb.GetPerMonth(Date.Year, Date.Month);
         var quality = db.Quality.GetPerMonth(Date.Year, Date.Month);
         var pressure = Pressure.GetItemsByMonth(Date);
         var kip = DevicesKip.GetItemsByMonth(Date);

         var qdl = new QualityDataList
         {
            Qualities = quality,
            Kg = charKg,
         };
         var q2 = new CalcQualities(new CalcQual2()).CalcEntities(qdl);

         var qualityData = from t1charKg in charKg
                           join t2qual in quality on new { t1charKg.Date } equals new { t2qual.Date }
                           select new QualityData
                           {
                              Kg = t1charKg,
                              Qualities = t2qual
                           };

         List<QualityDTO> qualities = new List<QualityDTO>(qualityData.Count());
         foreach (var item in qualityData)
         {
            qualities.Add(Calc.Quality.CalcEntity(item));
         }

         var wetGasData = from t1charKg in charKg
                          join t2charDg in charDg on new { t1charKg.Date } equals new { t2charDg.Date }
                          join t3kip in kip on new { t2charDg.Date } equals new { t3kip.Date }
                          join t4pressure in pressure on new { t3kip.Date } equals new { t4pressure.Date }
                          select new GasDensityData
                          {
                             CharacteristicsKg = t1charKg,
                             CharacteristicsDg = t2charDg,
                             Kip = t3kip,
                             Pressure = t4pressure,
                             Steam = steam,
                          };

         List<DensityDTO> wetGas = new List<DensityDTO>(wetGasData.Count());
         foreach (var item in wetGasData)
         {
            wetGas.Add(Calc.WetGas.CalcEntity(item));
         }

         var consKgData = from t1charKg in charKg
                          join t2wetGas in wetGas on new { t1charKg.Date } equals new { t2wetGas.Date }
                          join t3kip in kip on new { t2wetGas.Date } equals new { t3kip.Date }
                          select new ConsumptionKgData
                          {
                             WetGas = t2wetGas,
                             Kip = t3kip,
                             CharacteristicsKg = t1charKg,
                             Steam = steam,
                          };

         List<ConsumptionKgDTO> consKg = new List<ConsumptionKgDTO>(consKgData.Count());
         foreach (var item in consKgData)
         {
            consKg.Add(Calc.ConsumptionKg.CalcEntity(item));
         }

         var outputKgData = from t1wetGas in wetGas
                            join t2prod in prod on new { t1wetGas.Date } equals new { t2prod.Date }
                            join t3kip in kip on new { t2prod.Date } equals new { t3kip.Date }
                            join t4charKg in charKg on new { t3kip.Date } equals new { t4charKg.Date }
                            select new OutputKgData
                            {
                               WetGas = t1wetGas,
                               Production = t2prod,
                               Kip = t3kip,
                               CharacteristicsKg = t4charKg,
                               Steam = steam,
                            };

         List<OutputKgDTO> outputKg = new List<OutputKgDTO>(outputKgData.Count());
         foreach (var item in outputKgData)
         {
            outputKg.Add(Calc.OutputKg.CalcEntity(item));
         }

         var chartData = from t1prod in prod
                         join t2charKg in charKg on new { t1prod.Date } equals new { t2charKg.Date }
                         join t3qual in qualities on new { t2charKg.Date } equals new { t3qual.Date }
                         join t4outputKg in outputKg on new { t3qual.Date } equals new { t4outputKg.Date }
                         join t5consKg in consKg on new { t4outputKg.Date } equals new { t5consKg.Date }

      }
   }
}
