using Business.BusinessModels.DataForCalculations;
using Business.Interfaces.BaseCalculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessModels.BaseCalculations
{
   public class DensityDryGas : IDensity<DryGasDensityData>
   {
      public decimal Calc(DryGasDensityData obj)
      {
         if (obj.GetState() == "WithTempBefore")
         {

         }
         throw new NotImplementedException();
      }
   }
}
