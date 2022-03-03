using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
   public interface IYearable<T> where T : class
   {
      IEnumerable<T> GetItemsByYear(int Year);
      IEnumerable<T> GetItemsByNowYear();
   }
}
