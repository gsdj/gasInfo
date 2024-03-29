﻿using BLL.DTO;
using BLL.Interfaces.BaseCalculations;
using BLL.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace BLL.Calculations.Base
{
   public class DefaultQcRc : IQcRc
   {
      private Dictionary<int, SteamCharacteristicsDTO> SteamCharacteristics;
      private ISteamCharacteristicsService steamService;
      public DefaultQcRc(ISteamCharacteristicsService st)
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
      public decimal Calc(decimal cons, decimal wetGas, decimal temp, decimal density, bool perHour = false)
      {
         if (cons == 0 || wetGas == 0 || density == 0)
            return 0;

         int tempRounded = Convert.ToInt32(Math.Round(temp, MidpointRounding.ToEven));
         decimal Fkg = SteamCharacteristics[tempRounded].Fkg;

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
