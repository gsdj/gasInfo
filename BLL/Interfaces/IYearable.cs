using System.Collections.Generic;

namespace BLL.Interfaces
{
   public interface IYearable<T> where T : class
   {
      IEnumerable<T> GetItemsByYear(int Year);
   }
}
