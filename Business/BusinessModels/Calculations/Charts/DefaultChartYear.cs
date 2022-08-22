using Business.BusinessModels.BaseCalculations.Qn;
using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.DTO.Charts;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.BaseCalculations.Consumption;
using Business.Interfaces.BaseCalculations.Production;
using Business.Interfaces.Calculations;
using Business.Interfaces.Calculations.ConsGasQn;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.BusinessModels.Calculations.Charts
{
   public class DefaultChartYear : ICalculation<ChartYearDTO>, ICalculations<ChartYearDTO>
   {
      private ICalculation<DensityDTO> WetGas;
      private ICalcConsGasQnKc2 Kc2Qn;
      private ICalcConsGasQnCpsPpk CpsPpkQn;
      private IQcRc QcRc;
      private IConsGasQn<ConsGasQn4000> ConsGasQn;
      private ICokeCbConsumptionDryCalc CokeCbDry;
      public DefaultChartYear(ICalculation<DensityDTO> wetgas, ICalcConsGasQnKc2 kc2Qn, ICalcConsGasQnCpsPpk cpsppkQn, ICokeCbConsumptionDryCalc cokeCbDry)
      {
         WetGas = wetgas;
         Kc2Qn = kc2Qn;
         CpsPpkQn = cpsppkQn;
         CokeCbDry = cokeCbDry;
         QcRc = CpsPpkQn.CalcQcRcCpsPpk.QcRc;
         ConsGasQn = CpsPpkQn.ConsGasQn;
      }
      public IEnumerable<ChartYearDTO> CalcEntities(EnumerableData data)
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

         List<ChartYearDTO> chartYearDTO = new List<ChartYearDTO>(d.Count());

         foreach (var item in d)
         {
            chartYearDTO.Add(CalcEntity(item));
         }
         return chartYearDTO;
      }

      public ChartYearDTO CalcEntity(Data data)
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
            Kc2Sum = (consCbKc2.Sum == 0 && consCpsPpk.Pko.Total + consCpsPpk.Spo == 0) ? 0 : 
                     (consCbKc2.Sum + consCpsPpk.Pko.Total + consCpsPpk.Spo) / 24,

            GSUF4000 = (consGsuf == 0) ? 0 : consGsuf / 24,
            PrMk4000 = (PrMk4000 == 0) ? 0 : PrMk4000 / 24,

            TradeGasEB = Data.KgChmkEb.Consumption,
            TradeGasTn = CokeCbConsDry.Tn * 10,

            TradeGasAsdue = (Data.Asdue.StmDay == 0 || Data.CharacteristicsKg.Kc1.Qn == 0) ? 0 : 
                           ((Data.Asdue.StmDay / 24) * Data.CharacteristicsKg.Kc1.Qn) / 4000,
            
            TheorOutKg = (CokeCbConsDry.Cb1_6 == 0 || CokeCbConsDry.Tn == 0) ? 0 :
                       Math.Round((Data.Quality.Kc1.KgFh * (CokeCbConsDry.Cb1_6 / CokeCbConsDry.Tn) 
                       + Data.Quality.Kc2.KgFh * (CokeCbConsDry.Cb7_8 / CokeCbConsDry.Tn)) * 1000, 0),
         };

         return new ChartYearDTO
         {
            Date = wetGas.Date,
            TradeGasMK = Math.Round(data1.PrMk4000 - data1.Kc2Sum - data1.GSUF4000, 0),
            TradeGasEB = Math.Round(data1.TradeGasEB, 0),
            TradeGasTn = Math.Round(data1.TradeGasTn, 0),
            TradeGasAsdue = Math.Round(data1.TradeGasAsdue, 0),
            TradeGasV = (data1.TheorOutKg == 0) ? 0 : Math.Round(CokeCbConsDry.Tn * (data1.TheorOutKg / 24) - data1.Kc2Sum - data1.GSUF4000, 0),
            TradeGasDev = (data1.TradeGasEB == 0 || data1.TradeGasAsdue == 0) ? 0 : Math.Round((data1.TradeGasEB / data1.TradeGasAsdue) * 100, 0),
         };
      }
   }
}
