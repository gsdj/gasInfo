﻿using BLL.DataHelpers;
using BLL.Interfaces.BaseCalculations;
using BLL.Interfaces.Calculations;
using BLL.Models.BaseModels.QcRc;

namespace BLL.Calculations.Entities.QcRc
{
   public class CalcQcRcCpsPpk : ICalcQcRc<CpsPpkQcRc>
   {
      public CalcQcRcCpsPpk(IQcRc qcrc)
      {
         QcRc = qcrc;
      }

      public IQcRc QcRc { get; private set; }
      public CpsPpkQcRc Calc(QcRcData data)
      {
         QcRcKgData Data = data as QcRcKgData;
         var kip = Data.Kip;
         var charKg = Data.CharacteristicsKg;
         var wetGas = Data.WetGas;

         return new CpsPpkQcRc
         {
            Pko =
            {
               Pkp =
               {
                  Ms = QcRc.Calc(kip.CpsPpk.Pko.Pkp.Consumption.Ms, wetGas.CpsPpk.Pko.Pkp, kip.CpsPpk.Pko.Pkp.Temperature, charKg.Kc1.Density),
                  Ks = QcRc.Calc(kip.CpsPpk.Pko.Pkp.Consumption.Ks, wetGas.CpsPpk.Pko.Pkp, kip.CpsPpk.Pko.Pkp.Temperature, charKg.Kc1.Density),
               },
               Uvtp = QcRc.Calc(kip.CpsPpk.Pko.Uvtp.Consumption.Value, wetGas.CpsPpk.Pko.Uvtp, kip.CpsPpk.Pko.Uvtp.Temperature, charKg.Kc1.Density),
            },
            Spo = QcRc.Calc(kip.CpsPpk.Spo.Consumption.Value, wetGas.CpsPpk.Spo, kip.CpsPpk.Spo.Temperature, charKg.Kc1.Density),
         };
      }
   }
}
