using Business.BusinessModels.DataForCalculations;
using Business.DTO.Consumption;
using Business.DTO.Input;
using Business.Interfaces;
using Business.Interfaces.Services.Report;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;

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

         var consKgData = new EnumerableData
         {
            CharacteristicsDg = charDg,
            CharacteristicsKg = charKg,
            Kip = kip,
            Pressure = pressure,
         };

         var consKg = Calc.ConsumptionKg.CalcEntities(consKgData);

         return consKg;
      }
   }
}
