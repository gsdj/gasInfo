﻿using BLL.Interfaces.BaseCalculations;
using BLL.Models.BaseModels.General;
using DA.Entities;

namespace BLL.Interfaces.Calculations.Production
{
   public interface ICokeCbConsumptionFvCalc : ICalculations<AmmountCb, CbAll>, ICalculation<AmmountCb, CbAll> 
   {
      public CbKc CalcKc1(AmmountCb data);
      public CbKc CalcKc2(AmmountCb data);
   }
}
