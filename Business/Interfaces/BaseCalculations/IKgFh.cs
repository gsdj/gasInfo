using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.BaseCalculations
{
   public interface IKgFh
   {
      decimal KgFh(decimal V, decimal A, decimal W, decimal density);
   }
}
