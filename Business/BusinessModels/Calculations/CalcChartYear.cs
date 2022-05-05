using Business.BusinessModels.BaseCalculations;
using Business.BusinessModels.BaseCalculations.Qn;
using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.BaseCalculations.Consumption;
using Business.Interfaces.Calculations;
using Business.Interfaces.Calculations.ConsGasQn;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.BusinessModels.Calculations
{
   public class CalcChartYear : ICalculation<ChartYearDTO>, ICalculations<ChartYearDTO>
   {
      private ICalculation<DensityDTO> WetGas;
      private ICalcConsGasQnKc2 Kc2Qn;
      private ICalcConsGasQnCpsPpk CpsPpkQn;
      private IDryCokeProduction<DefaultDryCokeProduction> DryCoke;
      private IQcRc QcRc;
      private IConsGasQn<ConsGasQn4000> ConsGasQn;
      public CalcChartYear(ICalculation<DensityDTO> wetgas, ICalcConsGasQnKc2 kc2Qn, ICalcConsGasQnCpsPpk cpsppkQn,
                           IDryCokeProduction<DefaultDryCokeProduction> dryCoke)
      {
         WetGas = wetgas;
         Kc2Qn = kc2Qn;
         CpsPpkQn = cpsppkQn;
         DryCoke = dryCoke;
         QcRc = Kc2Qn.CalcQcRcKc2.QcRc;
         ConsGasQn = Kc2Qn.ConsGasQn;
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
         var consCb = Kc2Qn.Calc(qcrcKc2, charKg);

         var qcrcCpsPpk = CpsPpkQn.CalcQcRcCpsPpk.Calc(QcRcKgData);
         var consCpsPpk = CpsPpkQn.Calc(qcrcCpsPpk, charKg);
         var qcrcGsuf = CpsPpkQn.CalcQcRcCpsPpk.QcRc.Calc(kip.Gsuf45.Consumption.Value, wetGas.Gsuf, kip.Gsuf45.Temperature, charKg.Kc1.Characteristics.Density);

         var consGsuf = CpsPpkQn.ConsGasQn.Calc(qcrcGsuf, charKg.Kc1.Characteristics.Qn);
         var consKc2Sum = consCb.Cb1 + consCb.Cb2 + consCb.Cb3 + consCb.Cb4;
         var consCpsPpkSum = consCpsPpk.Pko.Pkp + consCpsPpk.Pko.Uvtp + consCpsPpk.Spo;

         var PrMk4000 = ConsGasQn.Calc(QcRc.Calc(kip.Cu.Cu1.Consumption.Value, wetGas.Cu.Cu1, kip.Cu.Cu1.Temperature, charKg.Kc1.Characteristics.Density), charKg.Kc1.Characteristics.Qn) +
                        ConsGasQn.Calc(QcRc.Calc(kip.Cu.Cu2.Consumption.Value, wetGas.Cu.Cu2, kip.Cu.Cu2.Temperature, charKg.Kc2.Characteristics.Density), charKg.Kc1.Characteristics.Qn);

         var Cb16ConsDry = (DryCoke.Calc(cbs.Cb1, cbs.OutputMultipliers.Cb1) + DryCoke.Calc(cbs.Cb2, cbs.OutputMultipliers.Cb2) +
                           DryCoke.Calc(cbs.Cb3, cbs.OutputMultipliers.Cb3) + DryCoke.Calc(cbs.Cb4, cbs.OutputMultipliers.Cb4) +
                           DryCoke.Calc(cbs.Cb5, cbs.OutputMultipliers.Cb5) + DryCoke.Calc(cbs.Cb6, cbs.OutputMultipliers.Cb6)) * cbs.OutputMultipliers.Sv;
         var Cb78ConsDry = (DryCoke.Calc(cbs.Cb7, cbs.OutputMultipliers.Cb7) + DryCoke.Calc(cbs.Cb8, cbs.OutputMultipliers.Cb8)) * cbs.OutputMultipliers.Sv;

         var TnConsDry = Cb16ConsDry + Cb78ConsDry;

         var data1 = new
         {
            Kc2Sum = (consKc2Sum == 0 && consCpsPpkSum == 0) ? 0 : (consKc2Sum + consCpsPpkSum) / 24,
            GSUF4000 = (consGsuf == 0) ? 0 : consGsuf / 24,
            PrMk4000 = (PrMk4000 == 0) ? 0 : PrMk4000 / 24,

            TradeGasEB = Data.KgChmkEb.Consumption,
            TradeGasTn = TnConsDry * 10,

            TradeGasAsdue = (Data.Asdue.StmDay == 0 || Data.CharacteristicsKg.Kc1.Characteristics.Qn == 0) ? 0 : ((Data.Asdue.StmDay / 24) * Data.CharacteristicsKg.Kc1.Characteristics.Qn) / 4000,
            TheorOutKg = (Cb16ConsDry == 0 || TnConsDry == 0) ? 0 :
                       Math.Round((Data.Quality.Kc1.KgFh * (Cb16ConsDry / TnConsDry) + Data.Quality.Kc2.KgFh * (Cb78ConsDry / TnConsDry)) * 1000, 0),
         };

         return new ChartYearDTO
         {
            Date = wetGas.Date,
            TradeGasMK = Math.Round(data1.PrMk4000 - data1.Kc2Sum - data1.GSUF4000, 0),
            TradeGasEB = Math.Round(data1.TradeGasEB, 0),
            TradeGasTn = Math.Round(data1.TradeGasTn, 0),
            TradeGasAsdue = Math.Round(data1.TradeGasAsdue, 0),
            TradeGasV = (data1.TheorOutKg == 0) ? 0 : Math.Round(TnConsDry * (data1.TheorOutKg / 24) - data1.Kc2Sum - data1.GSUF4000, 0),
            TradeGasDev = (data1.TradeGasEB == 0 || data1.TradeGasAsdue == 0) ? 0 : Math.Round((data1.TradeGasEB / data1.TradeGasAsdue) * 100, 0),
         };
      }
   }
}
