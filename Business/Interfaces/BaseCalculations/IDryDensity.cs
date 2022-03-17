using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.BaseCalculations
{
   public interface IDryDensity
   {
      decimal DryGas(decimal pkg, decimal PPa, decimal pOver, decimal temp);
      decimal DryGas(decimal pkg, decimal PPa, decimal pOver, decimal temp, decimal tempDo);
      decimal DryGas(decimal pkg, decimal PPa, decimal pOver, decimal temp, decimal rH, decimal pMax);
   }
}
