using Business.BusinessModels.BaseCalculations.Qn;
using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.DTO.Consumption;
using Business.DTO.General;
using Business.DTO.QcRc;
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
      public CpsPpk Calc(CpsPpkQcRc qcrc, CharacteristicsKgDTO cGas)
      {
         return new CpsPpk
         {
            Pko = 
            {
               Pkp = ConsGasQn.Calc(qcrc.Pko.Pkp.Value, cGas.Kc1.Characteristics.Qn),
               Uvtp = ConsGasQn.Calc(qcrc.Pko.Uvtp, cGas.Kc1.Characteristics.Qn),
            },
            //Pko = ConsGasQn.Calc(qcrc.Pko.Value + qcrc.Uvtp, cGas.Kc1.Characteristics.Qn),
            Spo = ConsGasQn.Calc(qcrc.Spo, cGas.Kc1.Characteristics.Qn),
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
