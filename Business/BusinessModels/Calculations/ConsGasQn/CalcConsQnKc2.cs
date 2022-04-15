﻿using Business.BusinessModels.BaseCalculations.Qn;
using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.DTO.Consumption;
using Business.DTO.QcRc;
using Business.Interfaces.BaseCalculations.Consumption;
using Business.Interfaces.Calculations;
using Business.Interfaces.Calculations.ConsGasQn;

namespace Business.BusinessModels.Calculations.ConsGasQn
{
   public class CalcConsQnKc2 : ICalcConsGasQnKc2<CalcConsQnKc2>
   {
      private IConsGasQn<ConsGasQn4000> ConsGasQn;
      public CalcConsQnKc2(ICalcQcRc<QcRcKc2> qcrc, IConsGasQn<ConsGasQn4000> consGasQn)
      {
         CalcQcRcKc2 = qcrc;
         ConsGasQn = consGasQn;
      }
      public ICalcQcRc<QcRcKc2> CalcQcRcKc2 { get; private set; }

      public ConsumptionKc2<decimal> Calc(QcRcKc2 qcrc, CharacteristicsKgDTO cGas)
      {
         return new ConsumptionKc2<decimal>
         {
            Cb5 = ConsGasQn.Calc(qcrc.Cb5, cGas.Kc1.Characteristics.Qn),
            Cb6 = ConsGasQn.Calc(qcrc.Cb6, cGas.Kc1.Characteristics.Qn),
            Cb7 = ConsGasQn.Calc(qcrc.Cb7.Value, cGas.Kc2.Characteristics.Qn),
            Cb8 = ConsGasQn.Calc(qcrc.Cb8.Value, cGas.Kc2.Characteristics.Qn),
         };
      }

      public ConsumptionKc2<decimal> Calc(QcRcData data)
      {
         var d1 = data as QcRcKgData;
         var charKg = d1.CharacteristicsKg;

         var qcrc = CalcQcRcKc2.Calc(data);

         return Calc(qcrc, charKg);
      }
   }
}