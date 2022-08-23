using BLL.Calculations.Base.Qn;
using BLL.DataHelpers;
using BLL.Interfaces.BaseCalculations.Consumption;
using BLL.Interfaces.Calculations;
using BLL.Interfaces.Calculations.ConsGasQn;
using BLL.Models.BaseModels.Characteristics.Gas;
using BLL.Models.BaseModels.General;
using BLL.Models.BaseModels.QcRc;

namespace BLL.Calculations.Entities.ConsGasQn
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
   }
}
