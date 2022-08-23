using BLL.Constants;
using BLL.DTO;
using BLL.Interfaces.Services;
using Business.Interfaces.BaseCalculations.Density;
using System;
using System.Collections.Generic;

namespace BLL.Calculations.Base.Density
{
   public class DryDensity : IDryDensity
   {
      private Dictionary<int, SteamCharacteristicsDTO> SteamCharacteristics;
      private ISteamCharacteristicsService steamService;
      public DryDensity(ISteamCharacteristicsService st)
      {
         steamService = st;
         SteamCharacteristics = steamService.GetCharacteristics();
      }

      public ISteamCharacteristicsService SteamCharacteristicsService
      {
         get
         {
            return steamService;
         }
         set
         {
            steamService = value;
            if (SteamCharacteristics == null || SteamCharacteristics.Count == 0)
               SteamCharacteristics = value.GetCharacteristics();
         }
      }

      public decimal Calc(decimal pkg, decimal PPa, decimal pOver, decimal temp)
      {
         int tempRounded = Convert.ToInt32(Math.Round(temp, MidpointRounding.ToEven));
         var steam = SteamCharacteristics[tempRounded];
         decimal rH = steam.Rh;
         decimal pMax = steam.PPa;

         decimal result = Calc(pkg, PPa, pOver, temp, rH, pMax);
         return Math.Round(result, 10);
      }

      public decimal Calc(decimal pkg, decimal PPa, decimal pOver, decimal temp, decimal tempDo)
      {
         int tempRounded = Convert.ToInt32(Math.Round(temp, MidpointRounding.ToEven));
         int tempDoRounded = Convert.ToInt32(Math.Round(tempDo, MidpointRounding.ToEven));
         decimal pMax = SteamCharacteristics[tempRounded].PPa;
         decimal rH = SteamCharacteristics[tempDoRounded].Rh;

         decimal result = Calc(pkg, PPa, pOver, temp, rH, pMax);
         return Math.Round(result, 10);
      }

      public decimal Calc(decimal pkg, decimal PPa, decimal pOver, decimal temp, decimal rH, decimal pMax)
      {
         decimal result = pkg * (GasConstants.Tc * ((PPa + pOver * GasConstants.PexcC) - rH * pMax)) / (GasConstants.Pc * (GasConstants.TpC + temp) * GasConstants.K);
         return result;
      }
   }
}
