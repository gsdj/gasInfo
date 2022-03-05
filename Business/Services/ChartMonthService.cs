using Business.DTO;
using Business.Interfaces.Services;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
   public class ChartMonthService : IChartMonthService
   {
      IUnitOfWork db;
      public ChartMonthService(IUnitOfWork uof, ICalcChartMonth)
      {
         db = uof;
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
