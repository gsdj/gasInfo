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
   public class CalcConsQnCpsPpk : ICalcConsGasQnCpsPpk<CalcConsQnCpsPpk>
   {
      private IConsGasQn<ConsGasQn4000> ConsGasQn;
      public CalcConsQnCpsPpk(ICalcQcRc<QcRcCpsPpk> qcrc, IConsGasQn<ConsGasQn4000> consGasQn)
      {
         CalcQcRcCpsPpk = qcrc;
         ConsGasQn = consGasQn;
      }
      public ICalcQcRc<QcRcCpsPpk> CalcQcRcCpsPpk { get; private set; }

      public ConsumptionCpsPpk Calc(QcRcCpsPpk qcrc, CharacteristicsKgDTO cGas)
      {
         return new ConsumptionCpsPpk
         {
            Pko = ConsGasQn.Calc(qcrc.Pko.Value + qcrc.Uvtp, cGas.Kc1.Characteristics.Qn),
            Spo = ConsGasQn.Calc(qcrc.Spo, cGas.Kc1.Characteristics.Qn),
         };
      }

      public ConsumptionCpsPpk Calc(QcRcData data)
      {
         var d1 = data as QcRcKgData;
         var charKg = d1.CharacteristicsKg;

         var qcrc = CalcQcRcCpsPpk.Calc(data);

         return Calc(qcrc, charKg);
      }
   }
}
