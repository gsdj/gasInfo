using Business.DTO;
using Business.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
   public class ChartMonthService : IChartMonthService
   {
      public IEnumerable<ChartMonthDTO> GetItemsByMonth(DateTime Date)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<ChartMonthDTO> GetItemsByNowMonth()
      {
         throw new NotImplementedException();
      }
   }
}
