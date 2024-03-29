﻿using BLL.Constants;
using BLL.Interfaces.BaseCalculations.Density;
using DA.Entities.Characteristics;

namespace BLL.Calculations.Base.Density
{
   public class DefaultDensityDg : IDensity<DG>
   {
      /// <summary>
      /// Плотность доменного газа
      /// </summary>
      /// <param name="dg"></param>
      /// <returns></returns>
      public decimal Calc(DG dg)
      {
         //return (0.01m * (dg.H2 * 0.0837m + dg.CO * 1.165m + dg.CO2 * 1.842m + dg.N2 * 1.166m));
         return (0.01m * (dg.H2 * PGasComponents.H2 + dg.CO * PGasComponents.CO + dg.CO2 * PGasComponents.CO2 + dg.N2 * PGasComponents.N2));
      }
   }
}
