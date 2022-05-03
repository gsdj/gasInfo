using Business.BusinessModels.BaseCalculations.Qn;
using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.DTO.Consumption;
using Business.DTO.QcRc;
using Business.Interfaces.BaseCalculations.Consumption;
using Business.Interfaces.Calculations;
using Business.Interfaces.Calculations.ConsGasQn;

namespace Business.BusinessModels.Calculations.ConsGasQn
{
   public class CalcConsQnKc1 : ICalcConsGasQnKc1
   {
      private IConsGasQn<ConsGasQn1000> ConsGasQn;
      public CalcConsQnKc1(ICalcQcRc<QcRcKc1> qcrc, IConsGasQn<ConsGasQn1000> consGasQn)
      {
         CalcQcRcKc1 = qcrc;
         ConsGasQn = consGasQn;
      }
      public ICalcQcRc<QcRcKc1> CalcQcRcKc1 { get; private set; }

      public ConsumptionKc1<decimal> Calc(QcRcKc1 qcrc, CharacteristicsDgDTO cGas)
      {
         return new ConsumptionKc1<decimal>
         {
            Cb1 = ConsGasQn.Calc(qcrc.Cb1.Value, cGas.CharacteristicsAVG.Qn),
            Cb2 = ConsGasQn.Calc(qcrc.Cb2.Value, cGas.CharacteristicsAVG.Qn),
            Cb3 = ConsGasQn.Calc(qcrc.Cb3.Value, cGas.CharacteristicsAVG.Qn),
            Cb4 = ConsGasQn.Calc(qcrc.Cb4.Value, cGas.CharacteristicsAVG.Qn),
         };
      }

      public ConsumptionKc1<decimal> Calc(QcRcData data)
      {
         var d1 = data as QcRcDgData;
         var charDg = d1.CharacteristicsDg;

         var qcrc = CalcQcRcKc1.Calc(data);

         return Calc(qcrc, charDg);
      }
   }
}
