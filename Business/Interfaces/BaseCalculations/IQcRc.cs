using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.BaseCalculations
{
   public interface IQcRc
   {
      decimal Calc(decimal cons, decimal wetGas, decimal temp, decimal density, bool perHour = false);
   }
}
