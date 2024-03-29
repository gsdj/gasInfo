﻿using BLL.DTO;
using BLL.Interfaces.Services;
using Business.Interfaces.BaseCalculations.Density;
using System;
using System.Collections.Generic;

namespace BLL.Calculations.Base.Density
{
   public class WetDensity : IWetDensity
   {
      private Dictionary<int, SteamCharacteristicsDTO> SteamCharacteristics;
      private ISteamCharacteristicsService steamService;
      public WetDensity(ISteamCharacteristicsService st)
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

      public decimal Calc(decimal dryGas, decimal temp)
      {
         int tempRounded = Convert.ToInt32(Math.Round(temp, MidpointRounding.ToEven));
         var steam = SteamCharacteristics[tempRounded];
         decimal rH = steam.Rh;
         decimal pMax = steam.PKg;

         decimal result = dryGas + rH * pMax;
         return Math.Round(result, 10);
      }
   }
}
