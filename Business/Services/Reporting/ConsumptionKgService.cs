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
   public class ConsumptionKgService : IConsumptionKgService
   {
      private IUnitOfWork db;
      private IUnitOfCalc Calc;
      private IMonthable<DevicesKipDTO> DevicesKip;
      private IMonthable<PressureDTO> Pressure;
      public ConsumptionKgService(IUnitOfWork uof, IUnitOfCalc calc, IMonthable<DevicesKipDTO> kip, IMonthable<PressureDTO> pressure)
      {
         db = uof;
         Calc = calc;
         DevicesKip = kip;
         Pressure = pressure;
      }
      public IEnumerable<ConsumptionKgDTO> GetItemsByMonth(DateTime Date)
      {
         return GetItemsByDate(Date);
      }

      public IEnumerable<ConsumptionKgDTO> GetItemsByNowMonth()
      {
         DateTime dateNow = DateTime.Now;
         return GetItemsByDate(dateNow);
      }

      private IEnumerable<ConsumptionKgDTO> GetItemsByDate(DateTime Date)
      {
         var charKg = Calc.CharacteristicsKg.CalcEntities(db.CharacteristicsKg.GetPerMonth(Date.Year, Date.Month));
         var charDg = Calc.CharacteristicsDg.CalcEntities(db.CharacteristicsDg.GetPerMonth(Date.Year, Date.Month));
         var steam = Calc.CharacteristicsSteam.CalcEntities(db.SteamCharacteristics.GetAll());
         var pressure = Pressure.GetItemsByMonth(Date);
         var kip = DevicesKip.GetItemsByMonth(Date);

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

         return consKg;
      }
   }
}
