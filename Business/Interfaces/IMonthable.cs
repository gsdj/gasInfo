using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
   public interface IMonthable<T> where T : class
   {
      IEnumerable<T> GetItemsByMonth(DateTime Date);
      IEnumerable<T> GetItemsByNowMonth();
   }
}
