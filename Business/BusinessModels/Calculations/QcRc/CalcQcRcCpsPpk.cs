﻿using Business.BusinessModels.DataForCalculations;
using Business.DTO.General;
using Business.DTO.QcRc;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.Calculations;

namespace Business.BusinessModels.Calculations.QcRc
{
   public class CalcQcRcCpsPpk : ICalcQcRc<CpsPpkQcRc>
   {
      private IQcRc QcRc;
      public CalcQcRcCpsPpk(IQcRc qcrc)
      {
         QcRc = qcrc;
      }

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
                  Ms = QcRc.Calc(kip.CpsPpk.Pko.Pkp.Consumption.Ms, wetGas.CpsPpk.Pko.Pkp, kip.CpsPpk.Pko.Pkp.Temperature, charKg.Kc1.Characteristics.Density),
                  //Ms = QcRc.Calc(kip.Pkc.ConsumptionMs, wetGas.Pkc, kip.Pkc.Temperature, charKg.Kc1.Characteristics.Density),
                  //Ks = QcRc.Calc(kip.Pkc.ConsumptionKs, wetGas.Pkc, kip.Pkc.Temperature, charKg.Kc1.Characteristics.Density),
                  Ks = QcRc.Calc(kip.CpsPpk.Pko.Pkp.Consumption.Ks, wetGas.CpsPpk.Pko.Pkp, kip.CpsPpk.Pko.Pkp.Temperature, charKg.Kc1.Characteristics.Density),
               },
               //Uvtp = QcRc.Calc(kip.Uvtp.Consumption, wetGas.Uvtp, kip.Uvtp.Temperature, charKg.Kc1.Characteristics.Density),
               Uvtp = QcRc.Calc(kip.CpsPpk.Pko.Uvtp.Consumption.Value, wetGas.CpsPpk.Pko.Uvtp, kip.CpsPpk.Pko.Uvtp.Temperature, charKg.Kc1.Characteristics.Density),
            },
            //Uvtp = QcRc.Calc(kip.Uvtp.Consumption, wetGas.Uvtp, kip.Uvtp.Temperature, charKg.Kc1.Characteristics.Density),
            //Spo = QcRc.Calc(kip.Spo.Consumption, wetGas.Spo, kip.Spo.Temperature, charKg.Kc1.Characteristics.Density),
            Spo = QcRc.Calc(kip.CpsPpk.Spo.Consumption.Value, wetGas.CpsPpk.Spo, kip.CpsPpk.Spo.Temperature, charKg.Kc1.Characteristics.Density),
            //Gsuf = QcRc.Calc(kip.Gsuf45.Consumption, wetGas.Gsuf, kip.Gsuf45.Temperature, charKg.Kc1.Characteristics.Density),
         };
      }
   }
}
