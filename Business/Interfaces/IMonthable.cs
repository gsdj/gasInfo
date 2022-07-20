using System;
using System.Collections.Generic;

namespace Business.Interfaces
{
   public interface IMonthable<T> where T : class
   {
      IEnumerable<T> GetItemsByMonth(DateTime Date);
      IEnumerable<T> GetItemsByNowMonth();
   }
}
