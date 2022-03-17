using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.BaseCalculations
{
   public interface IConsPg
   {
      decimal ConsPg(decimal cons, decimal PPa, decimal pressure, decimal temp);
   }
}
