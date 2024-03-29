﻿using BLL.DataHelpers;
using BLL.DTO.Consumption;
using BLL.DTO.Input;
using BLL.Interfaces;
using BLL.Interfaces.Services.Input;
using BLL.Interfaces.Services.Report;
using DA.Interfaces;
using System;
using System.Collections.Generic;

namespace BLL.Services.Reporting
{
   public class ConsumptionKgService : IConsumptionKgService
   {
      private IUnitOfWork db;
      private IUnitOfCalc Calc;
      private IDevicesKipService DevicesKip;
      private IPressureService Pressure;
      public ConsumptionKgService(IUnitOfWork uof, IUnitOfCalc calc, IDevicesKipService kip, IPressureService pressure)
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
