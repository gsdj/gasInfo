using Business.BusinessModels.BaseCalculations;
using Business.BusinessModels.BaseCalculations.Consumption;
using Business.BusinessModels.BaseCalculations.Qn;
using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.DTO.Models.General;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.BaseCalculations.Consumption;
using Business.Interfaces.Calculations;
using Business.Interfaces.Calculations.ConsGasQn;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.BusinessModels.Calculations
{
   public class CalcReportKg : ICalculation<ReportKgDTO>, ICalculations<ReportKgDTO>
   {
      private ICalculation<DensityDTO> WetGas;
      private ICalcConsGasQnKc2 Kc2Qn;
      private ICalcConsGasQnCpsPpk CpsPpkQn;
      private IChargeConsFV<DefaultChargeConsFV> ChargeConsFV;
      private IDryCokeProduction<DefaultDryCokeProduction> DryCoke;
      private ISpoPerKus<DefaultSpoPerKus> SpoPerKus;
      private ISpecificConsKgFv UdConsKgFv;
      private IConsGasQn<ConsGasQn4000> ConsGasQn;
      private IQcRc QcRc;

      public CalcReportKg(ICalculation<DensityDTO> wetGas, ISpecificConsKgFv udconskgfv, IDryCokeProduction<DefaultDryCokeProduction> cbdry, 
         ISpoPerKus<DefaultSpoPerKus> spoperkus, IChargeConsFV<DefaultChargeConsFV> consFv, ICalcConsGasQnKc2 kc2Qn, ICalcConsGasQnCpsPpk cpsppkQn)
      {
         WetGas = wetGas;
         DryCoke = cbdry;
         SpoPerKus = spoperkus;
         UdConsKgFv = udconskgfv;
         ChargeConsFV = consFv;
         Kc2Qn = kc2Qn;
         ConsGasQn = Kc2Qn.ConsGasQn;
         QcRc = Kc2Qn.CalcQcRcKc2.QcRc;
         CpsPpkQn = cpsppkQn;
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
         //v2------------
         var qcrcKc2_2 = Kc2Qn.CalcQcRcKc2.Calc(QcRcKgData);
         var consKgCb_2 = Kc2Qn.Calc(qcrcKc2_2, charKg);

         var qcrcCpsPpk_2 = CpsPpkQn.CalcQcRcCpsPpk.Calc(QcRcKgData);
         var consCpsPpk_2 = CpsPpkQn.Calc(qcrcCpsPpk_2, charKg);
         //--------------

         var ConsumptionFvKc2 = new CbKc
         {
            Cb1 = ChargeConsFV.Calc(cbs.Cb5, cbs.OutputMultipliers.Cb5, cbs.OutputMultipliers.Fv),
            Cb2 = ChargeConsFV.Calc(cbs.Cb6, cbs.OutputMultipliers.Cb6, cbs.OutputMultipliers.Fv),
            Cb3 = ChargeConsFV.Calc(cbs.Cb7, cbs.OutputMultipliers.Cb7, cbs.OutputMultipliers.Fv),
            Cb4 = ChargeConsFV.Calc(cbs.Cb8, cbs.OutputMultipliers.Cb8, cbs.OutputMultipliers.Fv),
         };

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
         var Cb16ConsDry = Math.Round(((DryCoke.Calc(cbs.Cb1, cbs.OutputMultipliers.Cb1) + DryCoke.Calc(cbs.Cb2, cbs.OutputMultipliers.Cb2) +
                                       DryCoke.Calc(cbs.Cb3, cbs.OutputMultipliers.Cb3) + DryCoke.Calc(cbs.Cb4, cbs.OutputMultipliers.Cb4) +
                                       DryCoke.Calc(cbs.Cb5, cbs.OutputMultipliers.Cb5) + DryCoke.Calc(cbs.Cb6, cbs.OutputMultipliers.Cb6)) * cbs.OutputMultipliers.Sv), 4);
         var Cb78ConsDry = Math.Round((DryCoke.Calc(cbs.Cb7, cbs.OutputMultipliers.Cb7) + DryCoke.Calc(cbs.Cb8, cbs.OutputMultipliers.Cb8)) * cbs.OutputMultipliers.Sv, 4);
         var TnConsDry = Math.Round(((DryCoke.Calc(cbs.Cb1, cbs.OutputMultipliers.Cb1) + DryCoke.Calc(cbs.Cb2, cbs.OutputMultipliers.Cb2) +
                                       DryCoke.Calc(cbs.Cb3, cbs.OutputMultipliers.Cb3) + DryCoke.Calc(cbs.Cb4, cbs.OutputMultipliers.Cb4) +
                                       DryCoke.Calc(cbs.Cb5, cbs.OutputMultipliers.Cb5) + DryCoke.Calc(cbs.Cb6, cbs.OutputMultipliers.Cb6) +
                                       DryCoke.Calc(cbs.Cb7, cbs.OutputMultipliers.Cb7) + DryCoke.Calc(cbs.Cb8, cbs.OutputMultipliers.Cb8)) * cbs.OutputMultipliers.Sv), 4);
         var PrMk4000 = ConsGasQn.Calc(QcRc.Calc(kip.Cu.Cu1.Consumption.Value, wetGas.Cu.Cu1, kip.Cu.Cu1.Temperature, charKg.Kc1.Density), charKg.Kc1.Qn) +
               ConsGasQn.Calc(QcRc.Calc(kip.Cu.Cu2.Consumption.Value, wetGas.Cu.Cu2, kip.Cu.Cu2.Temperature, charKg.Kc2.Density), charKg.Kc1.Qn);

         var data1 = new
         {
            SumKgCbsSpoGsuf = consKgCb_2.Cb1 + consKgCb_2.Cb2 + consKgCb_2.Cb3 + consKgCb_2.Cb4 + consCpsPpk_2.Spo + consGsuf,

            OutKgDryPkp = Math.Round((KpeDry * cbs.OutputMultipliers.Peka) / KpeDry, 10),
            OutKgPko = Math.Round(KpeDry * cbs.OutputMultipliers.Peka, 10),
         };

         var data2 = new
         {
            TradeGasChmk = Math.Round(tec.ChmkTecSum * 1000, 10),
            OutKgMk = Math.Round((data1.SumKgCbsSpoGsuf + consCpsPpk_2.Pko.Pkp + consCpsPpk_2.Pko.Uvtp) + (tec.ChmkTecSum * 1000), 10),
            KipSpr = Math.Round(PrMk4000 + consCpsPpk_2.Pko.Pkp + consCpsPpk_2.Pko.Uvtp, 10),
            OutKgCb18 = ((data1.SumKgCbsSpoGsuf + consCpsPpk_2.Pko.Pkp + consCpsPpk_2.Pko.Uvtp) + (tec.ChmkTecSum * 1000)) - data1.OutKgPko,

            OutKgCb16 = (cb1cb6 == 0 || mkCb == 0) ? 0 :
                        (((data1.SumKgCbsSpoGsuf + consCpsPpk_2.Pko.Pkp + consCpsPpk_2.Pko.Uvtp) +
                        (tec.ChmkTecSum * 1000)) - data1.OutKgPko) * cb1cb6 / mkCb,

            OutKgCb78 = (cb7cb8 == 0 || mkCb == 0) ? 0 :
                        (((data1.SumKgCbsSpoGsuf + consCpsPpk_2.Pko.Pkp + consCpsPpk_2.Pko.Uvtp) +
                        (tec.ChmkTecSum * 1000)) - data1.OutKgPko) * cb7cb8 / mkCb,
         };

         var consFvCpsPpk = new CpsPpk
         {
            Spo = UdConsKgFv.Calc(consCpsPpk_2.Spo, spoPerKus),
            Pko =
            {
               Pkp = UdConsKgFv.Calc(consCpsPpk_2.Pko.Pkp, KpeDry),// Math.Round(consCpsPpk_2.Pko.Pkp / KpeDry * GasConstants.ConsFvC, 10),
               Uvtp = UdConsKgFv.Calc(consCpsPpk_2.Pko.Uvtp, KpeDry), // Math.Round(consCpsPpk_2.Pko.Uvtp / KpeDry * GasConstants.ConsFvC, 10),
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
            OutKgDryCb16 = (cb1cb6 == 0 || mkCb == 0 || Cb16ConsDry == 0) ? 0 : Math.Round(data2.OutKgCb16 / Cb16ConsDry, 10),
            OutKgDryCb78 = (cb7cb8 == 0 || mkCb == 0 || Cb78ConsDry == 0) ? 0 : Math.Round(data2.OutKgCb78 / Cb78ConsDry, 10),
            OutKgDryMk = (data2.OutKgCb18 == 0 || TnConsDry == 0) ? 0 : Math.Round(data2.OutKgCb18 / TnConsDry, 10),
            ConsumptionKc2 = consKgCb_2,
            ConsKgKc2Sum = consKgCb_2.Cb1 + consKgCb_2.Cb2 + consKgCb_2.Cb3 + consKgCb_2.Cb4,
            ConsumptionCpsPpk = consCpsPpk_2,
            ConsKgUvtp = consCpsPpk_2.Pko.Uvtp,
            ConsumptionFvKc2 = consFvKc2,
            ConsFvKc2Sum = consFvKc2.Cb1 + consFvKc2.Cb2 + consFvKc2.Cb3 + consFvKc2.Cb4,
            ConsumptionFvCpsPpk = consFvCpsPpk,
            ConsKgCpsPpkSum = consFvCpsPpk.Pko.Pkp + consFvCpsPpk.Pko.Uvtp + consFvCpsPpk.Spo,
            ConsKgMk = consKgCb_2.Cb1 + consKgCb_2.Cb2 + consKgCb_2.Cb3 + consKgCb_2.Cb4 + consFvCpsPpk.Pko.Pkp + consFvCpsPpk.Pko.Uvtp + consFvCpsPpk.Spo,
            ConsFvCpsPpkSum = UdConsKgFv.Calc(consFvCpsPpk.Pko.Pkp + consFvCpsPpk.Pko.Uvtp + consFvCpsPpk.Spo, KpeDry),//UdConsKgCpsPpk
            ConsGsuf = consGsuf,
            TradeGasChmk = Math.Round(tec.ChmkTecSum * 1000, 10),
         };
      }
   }
}
