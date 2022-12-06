using BLL.Calculations.Base;
using BLL.Calculations.Base.Qn;
using BLL.DataHelpers;
using BLL.DTO;
using BLL.Interfaces.BaseCalculations;
using BLL.Interfaces.BaseCalculations.Consumption;
using BLL.Interfaces.Calculations;
using BLL.Interfaces.Calculations.ConsGasQn;
using BLL.Interfaces.Calculations.Production;
using BLL.Models.BaseModels.General;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Calculations.Entities
{
   public class DefaultReportKg : /*ICalculation<ReportKgDTO>, */ICalculations<ReportKgDTO>
   {
      private ICalculation<DensityDTO> WetGas;
      private ICalcConsGasQnKc2 Kc2Qn;
      private ICalcConsGasQnCpsPpk CpsPpkQn;
      private ISpoPerKus<DefaultSpoPerKus> SpoPerKus;
      private ISpecificConsKgFv UdConsKgFv;
      private IConsGasQn<ConsGasQn4000> ConsGasQn;
      private IQcRc QcRc;
      private ICokeCbConsumptionFvCalc CokeCbConsumptionFvCalc;
      private ICokeCbConsumptionDryCalc CokeCbConsumptionDryCalc;

      public DefaultReportKg(ICalculations<DensityDTO> wetGas, ISpecificConsKgFv udconskgfv, ISpoPerKus<DefaultSpoPerKus> spoperkus, 
         ICalcConsGasQnKc2 kc2Qn, ICalcConsGasQnCpsPpk cpsppkQn, ICokeCbConsumptionFvCalc consfv, ICokeCbConsumptionDryCalc consdry)
      {
         WetGas = wetGas;
         SpoPerKus = spoperkus;
         UdConsKgFv = udconskgfv;
         Kc2Qn = kc2Qn;
         ConsGasQn = Kc2Qn.ConsGasQn;
         QcRc = Kc2Qn.CalcQcRcKc2.QcRc;
         CpsPpkQn = cpsppkQn;
         CokeCbConsumptionFvCalc = consfv;
         CokeCbConsumptionDryCalc = consdry;
      }

      public IEnumerable<ReportKgDTO> CalcEntities(EnumerableData data)
      {
         var Data = data as ReportKgEnumData;
         var cbs = Data.AmmountCbs;
         var kip = Data.Kip;
         var charKg = Data.CharacteristicsKg;
         var charDg = Data.CharacteristicsDg;
         var pressure = Data.Pressure;
         var tec = Data.Tec;

         var d =
            from t1cbs in cbs
            join t2kip in kip on new { t1cbs.Date } equals new { t2kip.Date }
            join t3charKg in charKg on new { t2kip.Date } equals new { t3charKg.Date }
            join t4charDg in charDg on new { t3charKg.Date } equals new { t4charDg.Date }
            join t5tec in tec on new { t4charDg.Date } equals new { t5tec.Date }
            join t6pressure in pressure on new { t5tec.Date } equals new { t6pressure.Date }
            select new ReportKgData
            {
               AmmountCb = t1cbs,
               Kip = t2kip,
               CharacteristicsKg = t3charKg,
               CharacteristicsDg = t4charDg,
               Tec = t5tec,
               Pressure = t6pressure,
            };

         List<ReportKgDTO> reportKgDTO = new List<ReportKgDTO>(d.Count());

         foreach (var item in d)
         {
            reportKgDTO.Add(CalcEntity(item));
         }
         return reportKgDTO;
      }

      public ReportKgDTO CalcEntity(Data data)
      {
         ReportKgData Data = data as ReportKgData;
         var cbs = Data.AmmountCb;
         var kip = Data.Kip;
         var charKg = Data.CharacteristicsKg;
         var tec = Data.Tec;

         var wetGas = WetGas.CalcEntity(data);

         var QcRcKgData = new QcRcKgData
         {
            CharacteristicsKg = data.CharacteristicsKg,
            Kip = data.Kip,
            WetGas = wetGas,
         };

         var qcrcKc2_2 = Kc2Qn.CalcQcRcKc2.Calc(QcRcKgData);
         var consKgCb_2 = Kc2Qn.Calc(qcrcKc2_2, charKg);

         var qcrcCpsPpk_2 = CpsPpkQn.CalcQcRcCpsPpk.Calc(QcRcKgData);
         var consCpsPpk_2 = CpsPpkQn.Calc(qcrcCpsPpk_2, charKg);

         var ConsumptionFvKc2 = CokeCbConsumptionFvCalc.CalcKc2(cbs);
         var CokeCbConsumptionDry = CokeCbConsumptionDryCalc.CalcEntity(cbs);

         var consFvKc2 = new CbKc
         {
            Cb1 = UdConsKgFv.Calc(consKgCb_2.Cb1, ConsumptionFvKc2.Cb1),
            Cb2 = UdConsKgFv.Calc(consKgCb_2.Cb2, ConsumptionFvKc2.Cb2),
            Cb3 = UdConsKgFv.Calc(consKgCb_2.Cb3, ConsumptionFvKc2.Cb3),
            Cb4 = UdConsKgFv.Calc(consKgCb_2.Cb4, ConsumptionFvKc2.Cb4),
         };

         var qcrcGsuf = QcRc.Calc(kip.Gsuf45.Consumption.Value, wetGas.Gsuf, kip.Gsuf45.Temperature, charKg.Kc1.Density);
         var consGsuf = ConsGasQn.Calc(qcrcGsuf, charKg.Kc1.Qn);

         var KpeDry = Math.Round(cbs.PKP * cbs.OutputMultipliers.PKP, 4);
         var spoPerKus = SpoPerKus.Calc(cbs.PKP, cbs.OutputMultipliers.PKP, cbs.OutputMultipliers.Peka);

         var cb1cb6 = cbs.Cb1 + cbs.Cb2 + cbs.Cb3 + cbs.Cb4 + cbs.Cb5 + cbs.Cb6;
         var cb7cb8 = cbs.Cb7 + cbs.Cb8;
         var mkCb = cb1cb6 + cb7cb8;

         var PrMk4000 = ConsGasQn.Calc(QcRc.Calc(kip.Cu.Cu1.Consumption.Value, wetGas.Cu.Cu1, kip.Cu.Cu1.Temperature, charKg.Kc1.Density), charKg.Kc1.Qn) +
               ConsGasQn.Calc(QcRc.Calc(kip.Cu.Cu2.Consumption.Value, wetGas.Cu.Cu2, kip.Cu.Cu2.Temperature, charKg.Kc2.Density), charKg.Kc2.Qn);

         var data1 = new
         {
            SumKgCbsSpoGsuf = consKgCb_2.Sum + consCpsPpk_2.Spo + consGsuf,
            OutKgDryPkp = Math.Round((KpeDry * cbs.OutputMultipliers.Peka) / KpeDry, 10),
            OutKgPko = Math.Round(KpeDry * cbs.OutputMultipliers.Peka, 10),
         };

         var data2 = new
         {
            TradeGasChmk = Math.Round(tec.ChmkTecSum * 1000, 10),
            OutKgMk = Math.Round((data1.SumKgCbsSpoGsuf + consCpsPpk_2.Pko.Total) + (tec.ChmkTecSum * 1000), 10),
            KipSpr = Math.Round(PrMk4000 + consCpsPpk_2.Pko.Total, 10),
            OutKgCb18 = ((data1.SumKgCbsSpoGsuf + consCpsPpk_2.Pko.Total) + (tec.ChmkTecSum * 1000)) - data1.OutKgPko,

            OutKgCb16 = (cb1cb6 == 0 || mkCb == 0) ? 0 :
                        (((data1.SumKgCbsSpoGsuf + consCpsPpk_2.Pko.Total) +
                        (tec.ChmkTecSum * 1000)) - data1.OutKgPko) * cb1cb6 / mkCb,

            OutKgCb78 = (cb7cb8 == 0 || mkCb == 0) ? 0 :
                        (((data1.SumKgCbsSpoGsuf + consCpsPpk_2.Pko.Total) +
                        (tec.ChmkTecSum * 1000)) - data1.OutKgPko) * cb7cb8 / mkCb,
         };

         var consFvCpsPpk = new CpsPpk
         {
            Spo = UdConsKgFv.Calc(consCpsPpk_2.Spo, spoPerKus),
            Pko =
            {
               Pkp = UdConsKgFv.Calc(consCpsPpk_2.Pko.Pkp, KpeDry),
               Uvtp = UdConsKgFv.Calc(consCpsPpk_2.Pko.Uvtp, KpeDry),
            },
         };

         return new ReportKgDTO
         {
            Date = wetGas.Date,
            OutKgPko = data1.OutKgPko,
            OutKgCb16 = data2.OutKgCb16,
            OutKgCb78 = data2.OutKgCb78,
            OutKgCb18 = data2.OutKgCb18,
            OutKgMk = data2.OutKgMk,
            KipSpr = data2.KipSpr,
            OutKgDryPkp = data1.OutKgDryPkp,
            OutKgDryCb16 = (cb1cb6 == 0 || mkCb == 0 || CokeCbConsumptionDry.Cb1_6 == 0) ? 0 : Math.Round(data2.OutKgCb16 / CokeCbConsumptionDry.Cb1_6, 10),
            OutKgDryCb78 = (cb7cb8 == 0 || mkCb == 0 || CokeCbConsumptionDry.Cb7_8 == 0) ? 0 : Math.Round(data2.OutKgCb78 / CokeCbConsumptionDry.Cb7_8, 10),
            OutKgDryMk = (data2.OutKgCb18 == 0 || CokeCbConsumptionDry.Tn == 0) ? 0 : Math.Round(data2.OutKgCb18 / CokeCbConsumptionDry.Tn, 10),
            ConsumptionKc2 = consKgCb_2,
            ConsKgKc2Sum = consKgCb_2.Sum,
            ConsumptionCpsPpk = consCpsPpk_2,
            ConsKgUvtp = consCpsPpk_2.Pko.Uvtp,
            ConsumptionFvKc2 = consFvKc2,
            ConsFvKc2Sum = consKgCb_2.Sum / ConsumptionFvKc2.Sum * 0.57m,//не правильно ConsumptionKc2.sum/Production.CokeCbConsumptionFv.sum*0.57
            ConsumptionFvCpsPpk = consFvCpsPpk,
            ConsKgCpsPpkSum = consFvCpsPpk.Pko.Total + consFvCpsPpk.Spo,
            ConsKgMk = consKgCb_2.Sum + consFvCpsPpk.Pko.Total + consFvCpsPpk.Spo,
            ConsFvCpsPpkSum = UdConsKgFv.Calc(consFvCpsPpk.Pko.Total + consFvCpsPpk.Spo, KpeDry),//UdConsKgCpsPpk
            ConsGsuf = consGsuf,
            TradeGasChmk = Math.Round(tec.ChmkTecSum * 1000, 10),
         };
      }
   }
}
