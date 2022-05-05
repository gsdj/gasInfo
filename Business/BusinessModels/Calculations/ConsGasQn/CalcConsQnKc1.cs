using Business.BusinessModels.BaseCalculations.Qn;
using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.DTO.General;
using Business.DTO.QcRc;
using Business.Interfaces.BaseCalculations.Consumption;
using Business.Interfaces.Calculations;
using Business.Interfaces.Calculations.ConsGasQn;

namespace Business.BusinessModels.Calculations.ConsGasQn
{
   public class CalcConsQnKc1 : ICalcConsGasQnKc1
   {
      public ICalcQcRc<QcRcKc1> CalcQcRcKc1 { get; private set; }
      public IConsGasQn<ConsGasQn1000> ConsGasQn { get; private set; }
      public CalcConsQnKc1(ICalcQcRc<QcRcKc1> qcrc, IConsGasQn<ConsGasQn1000> consGasQn)
      {
         CalcQcRcKc1 = qcrc;
         ConsGasQn = consGasQn;
      }
      public CbKc Calc(QcRcKc1 qcrc, CharacteristicsDgDTO cGas)
      {
         return new CbKc
         {
            Cb1 = ConsGasQn.Calc(qcrc.Cb1.Value, cGas.CharacteristicsAVG.Qn),
            Cb2 = ConsGasQn.Calc(qcrc.Cb2.Value, cGas.CharacteristicsAVG.Qn),
            Cb3 = ConsGasQn.Calc(qcrc.Cb3.Value, cGas.CharacteristicsAVG.Qn),
            Cb4 = ConsGasQn.Calc(qcrc.Cb4.Value, cGas.CharacteristicsAVG.Qn),
         };
      }

      public CbKc Calc(QcRcData data)
      {
         var d1 = data as QcRcDgData;
         var charDg = d1.CharacteristicsDg;

         var qcrc = CalcQcRcKc1.Calc(data);

         return Calc(qcrc, charDg);
      }
   }
}
