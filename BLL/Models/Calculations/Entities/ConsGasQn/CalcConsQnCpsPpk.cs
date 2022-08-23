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
   public class CalcConsQnCpsPpk : ICalcConsGasQnCpsPpk
   {
      public ICalcQcRc<CpsPpkQcRc> CalcQcRcCpsPpk { get; private set; }
      public IConsGasQn<ConsGasQn4000> ConsGasQn { get; private set; }
      public CalcConsQnCpsPpk(ICalcQcRc<CpsPpkQcRc> qcrc, IConsGasQn<ConsGasQn4000> consGasQn)
      {
         CalcQcRcCpsPpk = qcrc;
         ConsGasQn = consGasQn;
      }
      public CpsPpk Calc(CpsPpkQcRc qcrc, CharacteristicsKG cGas)
      {
         return new CpsPpk
         {
            Pko = 
            {
               Pkp = ConsGasQn.Calc(qcrc.Pko.Pkp.Value, cGas.Kc1.Qn),
               Uvtp = ConsGasQn.Calc(qcrc.Pko.Uvtp, cGas.Kc1.Qn),
            },
            Spo = ConsGasQn.Calc(qcrc.Spo, cGas.Kc1.Qn),
         };
      }

      public CpsPpk Calc(QcRcData data)
      {
         var d1 = data as QcRcKgData;
         var charKg = d1.CharacteristicsKg;

         var qcrc = CalcQcRcCpsPpk.Calc(data);

         return Calc(qcrc, charKg);
      }
   }
}
