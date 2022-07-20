﻿using Business.BusinessModels.BaseCalculations.Qn;
using Business.BusinessModels.DataForCalculations;
using Business.DTO.Models.Characteristics.Gas;
using Business.DTO.Models.General;
using Business.DTO.Models.QcRc;
using Business.Interfaces.BaseCalculations.Consumption;
using Business.Interfaces.Calculations;
using Business.Interfaces.Calculations.ConsGasQn;

namespace Business.BusinessModels.Calculations.ConsGasQn
{
   public class CalcConsQnKc2 : ICalcConsGasQnKc2
   {
      public ICalcQcRc<QcRcKc2> CalcQcRcKc2 { get; private set; }
      public IConsGasQn<ConsGasQn4000> ConsGasQn { get; private set; }
      public CalcConsQnKc2(ICalcQcRc<QcRcKc2> qcrc, IConsGasQn<ConsGasQn4000> consGasQn)
      {
         CalcQcRcKc2 = qcrc;
         ConsGasQn = consGasQn;
      }
      public CbKc Calc(QcRcKc2 qcrc, CharacteristicsKG cGas)
      {
         return new CbKc
         {
            Cb1 = ConsGasQn.Calc(qcrc.Cb1.Value, cGas.Kc1.Qn),
            Cb2 = ConsGasQn.Calc(qcrc.Cb2.Value, cGas.Kc1.Qn),
            Cb3 = ConsGasQn.Calc(qcrc.Cb3.Value, cGas.Kc2.Qn),
            Cb4 = ConsGasQn.Calc(qcrc.Cb4.Value, cGas.Kc2.Qn),
         };
      }

      public CbKc Calc(QcRcData data)
      {
         var d1 = data as QcRcKgData;
         var charKg = d1.CharacteristicsKg;

         var qcrc = CalcQcRcKc2.Calc(data);

         return Calc(qcrc, charKg);
      }
   }
}
