using Business.DTO.Characteristics;
using Business.Interfaces;
using Business.Interfaces.BaseCalculations;
using System;
using System.Collections.Generic;

namespace Business.BusinessModels.BaseCalculations
{
   public class DefaultQcRc : IQcRc
   {
      private readonly Dictionary<int, SteamCharacteristicsDTO> _steam;
      public DefaultQcRc(ISteamCharacteristicsService st)
      {
         _steam = st.GetCharacteristics();
      }
      public decimal Calc(decimal cons, decimal wetGas, decimal temp, decimal density, bool perHour = false)
      {
         if (cons == 0 || wetGas == 0 || density == 0)
            return 0;

         int tempRounded = Convert.ToInt32(Math.Round(temp, MidpointRounding.ToEven));
         decimal Fkg = _steam[tempRounded].Fkg;

         if (!perHour)
         {
            decimal result = (cons * wetGas) * (1 - Fkg / wetGas) * 1 / density;
            return Math.Round(result, 10);
         }
         else
         {
            decimal result = (cons * 24 * wetGas) * (1 - Fkg / wetGas) * 1 / density;
            return Math.Round(result, 10);
         }
      }
   }
}
