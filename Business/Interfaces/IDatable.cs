using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
   public interface IDatable<T> where T : class
   {
      T GetItemByDate(DateTime Date);
   }
}
