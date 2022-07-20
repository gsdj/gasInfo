using System.Collections.Generic;

namespace Business.Interfaces
{
   public interface IYearable<T> where T : class
   {
      IEnumerable<T> GetItemsByYear(int Year);
      IEnumerable<T> GetItemsByNowYear();
   }
}
