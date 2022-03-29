using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.BaseCalculations
{
   public interface IChargeConsFV<T>
   {
      decimal Calc(int Cb, decimal CbCoef, decimal FvCoef);
   }
}
