using Business.BusinessModels.BaseCalculations.Qn;
using Business.BusinessModels.DataForCalculations;
using Business.DTO.Models.Characteristics.Gas;
using Business.DTO.Models.General;
using Business.DTO.Models.QcRc;
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
      public CbKc Calc(QcRcKc1 qcrc, CharacteristicsDG cGas)
      {
         return new CbKc
         {
            Cb1 = ConsGasQn.Calc(qcrc.Cb1.Value, cGas.AVG.Qn),
            Cb2 = ConsGasQn.Calc(qcrc.Cb2.Value, cGas.AVG.Qn),
            Cb3 = ConsGasQn.Calc(qcrc.Cb3.Value, cGas.AVG.Qn),
            Cb4 = ConsGasQn.Calc(qcrc.Cb4.Value, cGas.AVG.Qn),
         };
      }

      public CbKc Calc(QcRcData data)
      {
         var d1 = data as QcRcDgData;
         var charDg = d1.CharacteristicsDg;

         var qcrc = CalcQcRcKc1.Calc(data);

         return Calc(qcrc, charDg);
      }

      CbKc ICalcConsGasQn<CbKc, QcRcKc1, CharacteristicsDG, ConsGasQn1000>.Calc(QcRcKc1 qcrc, CharacteristicsDG cGas)
      {
         throw new System.NotImplementedException();
      }

      CbKc ICalcConsGasQn<CbKc, QcRcKc1, CharacteristicsDG, ConsGasQn1000>.Calc(QcRcData data)
      {
         throw new System.NotImplementedException();
      }
   }
}
