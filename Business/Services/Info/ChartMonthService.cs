using Business.DTO;
using Business.Interfaces;
using Business.Interfaces.Services;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;

namespace Business.Services.Info
{
   public class ChartMonthService : IChartMonthService
   {
      IUnitOfWork db;
      IUnitOfCalc Calc;
      public ChartMonthService(IUnitOfWork uof, IUnitOfCalc calc)
      {
         db = uof;
         Calc = calc;
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
   }
}
