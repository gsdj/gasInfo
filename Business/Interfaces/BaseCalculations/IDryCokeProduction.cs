using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.BaseCalculations
{
   public interface IDryCokeProduction<T>
   {
      decimal Calc(int cbAmmount, decimal cbCoef);
   }
}
