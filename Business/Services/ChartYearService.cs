using Business.DTO;
using Business.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
   public class ChartYearService : IChartYearService
   {
      public IEnumerable<ChartYearDTO> GetItemsByNowYear()
      {
         throw new NotImplementedException();
      }

      public IEnumerable<ChartYearDTO> GetItemsByYear(int Year)
      {
         throw new NotImplementedException();
      }
   }
}
