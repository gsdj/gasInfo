using Business.BusinessModels.BaseCalculations;
using Business.Interfaces.BaseCalculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessModels.Calculations
{
   public class CalcConsQnKc1 
   {
      private IConsGasQn<ConsGasQn1000> ConsQn;
      public CalcConsQnKc1(IConsGasQn<ConsGasQn1000> consQn)
      {
         ConsQn = consQn;
      }

   }
}
