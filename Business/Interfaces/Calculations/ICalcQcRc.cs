using Business.BusinessModels.DataForCalculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Calculations
{
   public interface ICalcQcRc<T>
   {
      T Calc(QcRcData data);
   }
}
