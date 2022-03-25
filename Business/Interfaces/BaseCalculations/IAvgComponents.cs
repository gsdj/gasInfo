using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.BaseCalculations
{
   public interface IAvgComponents<T,TResult>
   {
      TResult Calc(T obj);
   }
}
