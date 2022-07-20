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
