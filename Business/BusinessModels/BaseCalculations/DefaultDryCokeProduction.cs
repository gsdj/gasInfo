using Business.Interfaces;
using Business.Interfaces.BaseCalculations;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessModels.BaseCalculations
{
   public class DefaultDryCokeProduction : IDryCokeProduction<DefaultDryCokeProduction>
   {
      private IConstantsAll _cAll;
      private Constants Constants;
      public DefaultDryCokeProduction(IConstantsAll cAll)
      {
         _cAll = cAll;
         Constants = _cAll.GetConstants();
      }
      public decimal Calc(int cbAmmount, decimal cbCoef)
      {
         return cbAmmount * cbCoef * Constants.Kb18C;
      }
   }
}
