using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.BaseCalculations
{
   public interface IConsPgCb
   {
      decimal ConsPgCb(decimal consDg, decimal consPgKc, decimal kcSum);
   }
}
