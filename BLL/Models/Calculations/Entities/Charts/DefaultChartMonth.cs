using BLL.Calculations.Base.Qn;
using BLL.DataHelpers;
using BLL.DTO;
using BLL.DTO.Charts;
using BLL.Interfaces.BaseCalculations;
using BLL.Interfaces.BaseCalculations.Consumption;
using BLL.Interfaces.BaseCalculations.Production;
using BLL.Interfaces.Calculations;
using BLL.Interfaces.Calculations.ConsGasQn;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Calculations.Entities.Charts
{
   public class DefaultChartMonth : ICalculation<ChartMonthDTO>, ICalculations<ChartMonthDTO>
   {
      private ICalculation<DensityDTO> WetGas;
      private ICalcConsGasQnKc2 Kc2Qn;
      private ICalcConsGasQnCpsPpk CpsPpkQn;
      private IQcRc QcRc;
      private IConsGasQn<ConsGasQn4000> ConsGasQn;
      private ICokeCbConsumptionDryCalc CokeCbDry;
      public DefaultChartMonth(ICalculation<DensityDTO> wetgas, ICalcConsGasQnKc2 kc2Qn, ICalcConsGasQnCpsPpk cpsppkQn, ICokeCbConsumptionDryCalc cokeCbDry)
      {
         WetGas = wetgas;
         Kc2Qn = kc2Qn;
         CpsPpkQn = cpsppkQn;
         CokeCbDry = cokeCbDry;
         QcRc = CpsPpkQn.CalcQcRcCpsPpk.QcRc;
         ConsGasQn = CpsPpkQn.ConsGasQn;
      }
      public IEnumerable<ChartMonthDTO> CalcEntities(EnumerableData data)
      {
         var Data = data as ChartEnumData;

         var cbs = Data.AmmountCbs;
         var charKg = Data.CharacteristicsKg;
         var quality = Data.Quality;
         var asdue = Data.Asdue;
         var kgChmk = Data.KgChmkEb;
         
         var d =
            from t1cbs in cbs
            join t2charKg in charKg on new { t1cbs.Date } equals new { t2charKg.Date }
            join t3quality in quality on new { t2charKg.Date } equals new { t3quality.Date }
            join t4asdue in asdue on new { t3quality.Date } equals new { t4asdue.Date }
            join t5kgChmk in kgChmk on new { t4asdue.Date } equals new { t5kgChmk.Date }
            select new ChartData
            {
               AmmountCb = t1cbs,
               CharacteristicsKg = t2charKg,
               Quality = t3quality,
               Asdue = t4asdue,
               KgChmkEb = t5kgChmk
            };

         List<ChartMonthDTO> chartMonthDTO = new List<ChartMonthDTO>(d.Count());

         foreach (var item in d)
         {
            chartMonthDTO.Add(CalcEntity(item));
         }
         return chartMonthDTO;
      }

      public ChartMonthDTO CalcEntity(Data data)
      {
         ChartData Data = data as ChartData;

         var cbs = Data.AmmountCb;
         var kip = data.Kip;
         var charKg = data.CharacteristicsKg;

         var wetGas = WetGas.CalcEntity(data);

         var QcRcKgData = new QcRcKgData
         {
            CharacteristicsKg = data.CharacteristicsKg,
            Kip = data.Kip,
            WetGas = wetGas,
         };

         //---v2---
         var qcrcKc2 = Kc2Qn.CalcQcRcKc2.Calc(QcRcKgData);
         var consCbKc2 = Kc2Qn.Calc(qcrcKc2, charKg);

         var qcrcCpsPpk = CpsPpkQn.CalcQcRcCpsPpk.Calc(QcRcKgData);
         var consCpsPpk = CpsPpkQn.Calc(qcrcCpsPpk, charKg);
         var qcrcGsuf = CpsPpkQn.CalcQcRcCpsPpk.QcRc.Calc(kip.Gsuf45.Consumption.Value, wetGas.Gsuf, kip.Gsuf45.Temperature, charKg.Kc1.Density);

         var consGsuf = CpsPpkQn.ConsGasQn.Calc(qcrcGsuf, charKg.Kc1.Qn);

         var PrMk4000 = ConsGasQn.Calc(QcRc.Calc(kip.Cu.Cu1.Consumption.Value, wetGas.Cu.Cu1, kip.Cu.Cu1.Temperature, charKg.Kc1.Density), charKg.Kc1.Qn) +
                        ConsGasQn.Calc(QcRc.Calc(kip.Cu.Cu2.Consumption.Value, wetGas.Cu.Cu2, kip.Cu.Cu2.Temperature, charKg.Kc2.Density), charKg.Kc2.Qn);

         var CokeCbConsDry = CokeCbDry.CalcEntity(cbs);

         var data1 = new
         {
            Kc2Sum = (consCbKc2.Sum + consCpsPpk.Pko.Total + consCpsPpk.Spo) / 24,
            Gsuf4000 = consGsuf / 24,
            Asdue = (Data.Asdue.StmDay / 24) * Data.CharacteristicsKg.Kc1.Qn / 4000,
            Oper = PrMk4000 / CokeCbConsDry.Tn,
         };

         return new ChartMonthDTO
         {
            Date = wetGas.Date,
            TheorOutKg = (CokeCbConsDry.Cb1_6 == 0 || CokeCbConsDry.Tn == 0) ? 0 :
                           Math.Round((Data.Quality.Kc1.KgFh * (CokeCbConsDry.Cb1_6 / CokeCbConsDry.Tn) + Data.Quality.Kc2.KgFh * (CokeCbConsDry.Cb7_8 / CokeCbConsDry.Tn)) * 1000, 0),
            OperOutKg = Math.Round(data1.Oper, 0),
            TradeOutKg = (CokeCbConsDry.Tn == 0) ? 0 : Math.Round((data1.Kc2Sum + data1.Gsuf4000 + data1.Asdue) * 24 / CokeCbConsDry.Tn, 0),
            TradeChmkOutKg = (CokeCbConsDry.Tn == 0) ? 0 : Math.Round((data1.Kc2Sum + data1.Gsuf4000 + Data.KgChmkEb.Consumption) * 24 / CokeCbConsDry.Tn, 0),
         };
      }
   }
}
