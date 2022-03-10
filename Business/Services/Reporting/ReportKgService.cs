using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.Interfaces;
using Business.Interfaces.Services;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services.Reporting
{
   public class ReportKgService : IReportKgService
   {
      IUnitOfWork Db;
      IUnitOfCalc Calc;
      IMonthable<DevicesKipDTO> DevicesKip;
      IMonthable<PressureDTO> Pressure;
      public ReportKgService(IUnitOfWork uof, IUnitOfCalc calc, IMonthable<DevicesKipDTO> kip, IMonthable<PressureDTO> pressure)
      {
         Db = uof;
         Calc = calc;
         DevicesKip = kip;
         Pressure = pressure;
      }
      public IEnumerable<ReportKgDTO> GetItemsByMonth(DateTime Date)
      {
         return GetItemsByDate(Date);
      }

      public IEnumerable<ReportKgDTO> GetItemsByNowMonth()
      {
         DateTime dateNow = DateTime.Now;
         return GetItemsByDate(dateNow);
      }

      private IEnumerable<ReportKgDTO> GetItemsByDate(DateTime Date)
      {
         var charKg = Calc.CharacteristicsKg.CalcEntities(Db.CharacteristicsKg.GetPerMonth(Date.Year, Date.Month));
         var charDg = Calc.CharacteristicsDg.CalcEntities(Db.CharacteristicsDg.GetPerMonth(Date.Year, Date.Month));
         var pressure = Pressure.GetItemsByMonth(Date);
         var prod = Calc.Production.CalcEntities(Db.AmmountCb.GetPerMonth(Date.Year, Date.Month));
         var kip = DevicesKip.GetItemsByMonth(Date);
         var tec = Calc.Tec.CalcEntities(Db.Tec.GetPerMonth(Date.Year, Date.Month));
         var steam = Calc.CharacteristicsSteam.CalcEntities(Db.SteamCharacteristics.GetAll());

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

         var reportKgData = from t1prod in prod
                            join t2consKg in consKg on new { t1prod.Date } equals new { t2consKg.Date }
                            join t3kip in kip on new { t2consKg.Date } equals new { t3kip.Date }
                            join t4charKg in charKg on new { t3kip.Date } equals new { t4charKg.Date }
                            join t5outputKg in outputKg on new { t4charKg.Date } equals new { t5outputKg.Date }
                            join t6tec in tec on new { t5outputKg.Date } equals new { t6tec.Date }
                            select new ReportKgData
                            {
                               Production = t1prod,
                               ConsKg = t2consKg,
                               Kip = t3kip,
                               CharacteristicsKg = t4charKg,
                               OutputKg = t5outputKg,
                               Tec = t6tec,
                            };
         List<ReportKgDTO> reportKg = new List<ReportKgDTO>(reportKgData.Count());
         foreach (var item in reportKgData)
         {
            reportKg.Add(Calc.ReportKg.CalcEntity(item));
         }

         return reportKg;
      }
   }
}
