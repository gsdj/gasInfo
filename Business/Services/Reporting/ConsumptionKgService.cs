using Business.BusinessModels;
using Business.BusinessModels.Calculations;
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
         var pressure = Pressure.GetItemsByMonth(Date);
         var kip = DevicesKip.GetItemsByMonth(Date);

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

         return consKg;
      }
   }
}
