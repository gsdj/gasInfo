﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.BaseCalculations
{
   public interface IWetDensity
   {
      ISteamCharacteristicsService SteamCharacteristicsService { get; set; }
      decimal Calc(decimal dryGas, decimal temp);
   }
}
