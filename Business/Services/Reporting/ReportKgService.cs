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
         var kip = DevicesKip.GetItemsByMonth(Date);
         var tec = Calc.Tec.CalcEntities(Db.Tec.GetPerMonth(Date.Year, Date.Month));
         var cbs = Db.AmmountCb.GetPerMonth(Date.Year, Date.Month);

         var reportKgData = new ReportKgEnumData
         {
            CharacteristicsKg = charKg,
            Kip = kip,
            CharacteristicsDg = charDg,
            Pressure = pressure,
            AmmountCbs = cbs,
            Tec = tec,
         };

         var reportKg = Calc.ReportKg.CalcEntities(reportKgData);

         return reportKg;
      }
   }
}
