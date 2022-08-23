using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
   public interface IMonthable<T> where T : class
   {
      IEnumerable<T> GetItemsByMonth(DateTime Date);
      IEnumerable<T> GetItemsByNowMonth();
   }
}
