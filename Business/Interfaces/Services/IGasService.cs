using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
   public interface IGasService<T> 
   {
      T GetByDate(DateTime Date);
      IEnumerable<T> GetAllByNowMonth();
      IEnumerable<T> GetAllByMonth(DateTime Date);
      IEnumerable<T> GetAllByNowYear();
      IEnumerable<T> GetAllByYear(int Year);
   }
}
