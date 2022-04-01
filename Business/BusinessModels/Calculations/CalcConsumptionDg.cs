using Business.BusinessModels.BaseCalculations;
using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.DTO.Consumption;
using Business.DTO.QcRc;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.Calculations;
using System.Collections.Generic;
using System.Linq;

namespace Business.BusinessModels.Calculations
{
   public class CalcConsumptionDg : ICalculation<ConsumptionDgDTO>, ICalculations<ConsumptionDgDTO>
   {
      private ICalculation<DensityDTO> WetGas;
      private IConsGasQn<ConsGasQn1000> ConsGasQn;
      private ICalcQcRc<QcRcKc1> QcRcKc1;
      public CalcConsumptionDg(ICalculation<DensityDTO> wetGas, ICalcQcRc<QcRcKc1> qcrcKc1, IConsGasQn<ConsGasQn1000> consGasQn)
      {
         WetGas = wetGas;
         QcRcKc1 = qcrcKc1;
         ConsGasQn = consGasQn;
      }
      public IEnumerable<ConsumptionDgDTO> CalcEntities(EnumerableData data)
      {
         var d =
            from t1charDg in data.CharacteristicsDg
            join t2kip in data.Kip on new { t1charDg.Date } equals new { t2kip.Date }
            join t3charKg in data.CharacteristicsKg on new { t2kip.Date } equals new { t3charKg.Date }
            join t4pressure in data.Pressure on new { t3charKg.Date } equals new { t4pressure.Date }
            select new Data
            {
               CharacteristicsDg = t1charDg,
               Kip = t2kip,
               CharacteristicsKg = t3charKg,
               Pressure = t4pressure,
            };

         List<ConsumptionDgDTO> consdgDTO = new List<ConsumptionDgDTO>(d.Count());

         foreach (var item in d)
         {
            consdgDTO.Add(CalcEntity(item));
         }
         return consdgDTO;
      }

      public ConsumptionDgDTO CalcEntity(Data data)
      {
         var charDg = data.CharacteristicsDg;

         var wetGas = WetGas.CalcEntity(data);

         var QcRcDgData = new QcRcDgData
         {
            CharacteristicsDg = data.CharacteristicsDg,
            Kip = data.Kip,
            WetGas = wetGas,
         };

         var qcrcKc1 = QcRcKc1.Calc(QcRcDgData);

         var cons = new ConsumptionKc1<decimal>
         {
            Cb1 = ConsGasQn.Calc(qcrcKc1.Cb1, charDg.CharacteristicsAVG.Qn),
            Cb2 = ConsGasQn.Calc(qcrcKc1.Cb1, charDg.CharacteristicsAVG.Qn),
            Cb3 = ConsGasQn.Calc(qcrcKc1.Cb1, charDg.CharacteristicsAVG.Qn),
            Cb4 = ConsGasQn.Calc(qcrcKc1.Cb1, charDg.CharacteristicsAVG.Qn),
         };

         return new ConsumptionDgDTO
         {
            Date = wetGas.Date,
            QcRc = qcrcKc1,
            ConsumptionDg = cons,
            ConsumptionDgMk = cons.Cb1 + cons.Cb2 + cons.Cb3 + cons.Cb4,
         };
      }
   }
}
