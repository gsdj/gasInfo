using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.BaseCalculations
{
   public interface IUdConsDgFv
   {
      decimal UdConsDgFv(decimal consDg, decimal consPg, decimal consFv);
   }
}
