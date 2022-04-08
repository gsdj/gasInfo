using Business.BusinessModels.BaseCalculations;
using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.DTO.Characteristics;
using Business.DTO.Consumption;
using Business.DTO.QcRc;
using Business.Interfaces;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.BusinessModels.Calculations
{
   public class CalcReportKg : ICalculation<ReportKgDTO>, ICalculations<ReportKgDTO>
   {
      private ICalculation<DensityDTO> WetGas;
      private IDryCokeProduction<DefaultDryCokeProduction> DryCoke;
      private IConsGasQn<ConsGasQn4000> ConsGasQn;
      private ISpoPerKus<DefaultSpoPerKus> SpoPerKus;
      private IUdConsKgFv UdConsKgFv;
      private ICalcQcRc<QcRcKc2> QcRcKc2;
      private ICalcQcRc<QcRcCpsPpk> QcRcCpsPpk;
      private IChargeConsFV<DefaultChargeConsFV> ChargeConsFV;
      private IQcRc QcRc;
      public CalcReportKg(ICalculation<DensityDTO> wetGas, ICalcQcRc<QcRcKc2> qcrcKc2, ICalcQcRc<QcRcCpsPpk> qcrcCpsppk, IUdConsKgFv udconskgfv, IQcRc qcrc,
         IDryCokeProduction<DefaultDryCokeProduction> cbdry, IConsGasQn<ConsGasQn4000> consGasqn, ISpoPerKus<DefaultSpoPerKus> spoperkus, IChargeConsFV<DefaultChargeConsFV> cconsFv)
      {
         WetGas = wetGas;
         DryCoke = cbdry;
         QcRc = qcrc;
         QcRcKc2 = qcrcKc2;
         QcRcCpsPpk = qcrcCpsppk;
         ConsGasQn = consGasqn;
         SpoPerKus = spoperkus;
         UdConsKgFv = udconskgfv;
         ChargeConsFV = cconsFv;
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
         var charDg = Data.CharacteristicsDg;
         var pressure = Data.Pressure;
         var tec = Data.Tec;

         var wetGas = WetGas.CalcEntity(data);

         var QcRcKgData = new QcRcKgData
         {
            CharacteristicsKg = data.CharacteristicsKg,
            Kip = data.Kip,
            WetGas = wetGas,
         };

         var qcrcKc2 = QcRcKc2.Calc(QcRcKgData);
         var qcrcCpsPpk = QcRcCpsPpk.Calc(QcRcKgData);

         var ConsKgCb = new ConsumptionKc2<decimal>
         {
            Cb5 = ConsGasQn.Calc(qcrcKc2.Cb5, charKg.Kc1.Characteristics.Qn),
            Cb6 = ConsGasQn.Calc(qcrcKc2.Cb6, charKg.Kc1.Characteristics.Qn),
            Cb7 = ConsGasQn.Calc(qcrcKc2.Cb7.Value, charKg.Kc2.Characteristics.Qn),
            Cb8 = ConsGasQn.Calc(qcrcKc2.Cb8.Value, charKg.Kc2.Characteristics.Qn),
         };

         var consCpsPpk = new ConsumptionCpsPpk
         {
            Pko = ConsGasQn.Calc(qcrcCpsPpk.Pko.Value + qcrcCpsPpk.Uvtp, charKg.Kc1.Characteristics.Qn),
            Spo = ConsGasQn.Calc(qcrcCpsPpk.Spo, charKg.Kc1.Characteristics.Qn),
         };

         var ConsumptionFvKc2 = new ConsumptionKc2<decimal>
         {
            Cb5 = ChargeConsFV.Calc(cbs.Cb5, cbs.OutputMultipliers.Cb5, cbs.OutputMultipliers.Fv),
            Cb6 = ChargeConsFV.Calc(cbs.Cb6, cbs.OutputMultipliers.Cb6, cbs.OutputMultipliers.Fv),
            Cb7 = ChargeConsFV.Calc(cbs.Cb7, cbs.OutputMultipliers.Cb7, cbs.OutputMultipliers.Fv),
            Cb8 = ChargeConsFV.Calc(cbs.Cb8, cbs.OutputMultipliers.Cb8, cbs.OutputMultipliers.Fv),
         };

         //var consKc2 = new ConsumptionKc2<decimal>
         //{
         //   Cb5 = Math.Round(consKg.ConsumptionCb.Cb5),
         //   Cb6 = Math.Round(consKg.ConsumptionCb.Cb6),
         //   Cb7 = Math.Round(consKg.ConsumptionCb.Cb7),
         //   Cb8 = Math.Round(consKg.ConsumptionCb.Cb8),
         //};

         //var consCpsPpk = new ConsumptionCpsPpk
         //{
         //   Spo = Math.Round(consKg.ConsumptionCpsPpk.Spo),
         //   Pko = Math.Round(consKg.QcRcCpsPpk.Pko.Value * charKg.Kc1.Characteristics.Qn / 4000),
         //};

         var consFvKc2 = new ConsumptionKc2<decimal>
         {
            Cb5 = UdConsKgFv.Calc(ConsKgCb.Cb5, ConsumptionFvKc2.Cb5),
            Cb6 = UdConsKgFv.Calc(ConsKgCb.Cb6, ConsumptionFvKc2.Cb6),
            Cb7 = UdConsKgFv.Calc(ConsKgCb.Cb7, ConsumptionFvKc2.Cb7),
            Cb8 = UdConsKgFv.Calc(ConsKgCb.Cb8, ConsumptionFvKc2.Cb8),
         };

         var consGsuf = ConsGasQn.Calc(qcrcCpsPpk.Gsuf, charKg.Kc1.Characteristics.Qn);
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
         var PrMk4000 = ConsGasQn.Calc(QcRc.Calc(kip.Cu1.Consumption, wetGas.Cu1, kip.Cu1.Temperature, charKg.Kc1.Characteristics.Density), charKg.Kc1.Characteristics.Qn) +
               ConsGasQn.Calc(QcRc.Calc(kip.Cu2.Consumption, wetGas.Cu2, kip.Cu2.Temperature, charKg.Kc2.Characteristics.Density), charKg.Kc1.Characteristics.Qn);

         var data1 = new
         {
            SumKgCbsSpoGsuf = ConsKgCb.Cb5 + ConsKgCb.Cb6 + ConsKgCb.Cb7 + ConsKgCb.Cb8 + consCpsPpk.Spo + consGsuf,
            ConsKgUvtp = qcrcCpsPpk.Uvtp == 0 || charKg.Kc1.Characteristics.Qn == 0 ? 0 :
                        Math.Round(qcrcCpsPpk.Uvtp * charKg.Kc1.Characteristics.Qn / 4000, 10),

            OutKgDryPkp = Math.Round((KpeDry * cbs.OutputMultipliers.Peka) / KpeDry, 10),
            OutKgPko = Math.Round(KpeDry * cbs.OutputMultipliers.Peka, 10),
         };

         var data2 = new
         {
            TradeGasChmk = Math.Round(tec.ChmkTecSum * 1000, 10),
            OutKgMk = Math.Round((data1.SumKgCbsSpoGsuf + consCpsPpk.Pko + data1.ConsKgUvtp) + (tec.ChmkTecSum * 1000), 10),
            KipSpr = Math.Round(PrMk4000 + consCpsPpk.Pko + data1.ConsKgUvtp, 10),
            OutKgCb18 = ((data1.SumKgCbsSpoGsuf + consCpsPpk.Pko + data1.ConsKgUvtp) + (tec.ChmkTecSum * 1000)) - data1.OutKgPko,
            ConsFvPko = Math.Round((consCpsPpk.Pko + data1.ConsKgUvtp) / KpeDry * GasConstants.ConsFvC, 10),
            ConsFvCpsPpk = Math.Round((consCpsPpk.Spo + consCpsPpk.Pko + data1.ConsKgUvtp) / spoPerKus * GasConstants.ConsFvC, 10),

            OutKgCb16 = (cb1cb6 == 0 || mkCb == 0) ? 0 :
                        (((data1.SumKgCbsSpoGsuf + consCpsPpk.Pko + data1.ConsKgUvtp) +
                        (tec.ChmkTecSum * 1000)) - data1.OutKgPko) * cb1cb6 / mkCb,

            OutKgCb78 = (cb7cb8 == 0 || mkCb == 0) ? 0 :
                        (((data1.SumKgCbsSpoGsuf + consCpsPpk.Pko + data1.ConsKgUvtp) +
                        (tec.ChmkTecSum * 1000)) - data1.OutKgPko) * cb7cb8 / mkCb,
         };

         var consFvCpsPpk = new ConsumptionCpsPpk
         {
            Spo = UdConsKgFv.Calc(consCpsPpk.Spo, spoPerKus),
            Pko = Math.Round((consCpsPpk.Pko + data1.ConsKgUvtp) / KpeDry * GasConstants.ConsFvC, 10),
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
            ConsumptionKc2 = ConsKgCb,
            ConsKgKc2Sum = ConsKgCb.Cb5 + ConsKgCb.Cb6 + ConsKgCb.Cb7 + ConsKgCb.Cb8,
            ConsumptionCpsPpk = consCpsPpk,
            ConsKgUvtp = data1.ConsKgUvtp,
            ConsumptionFvKc2 = consFvKc2,
            ConsFvKc2Sum = consFvKc2.Cb5 + consFvKc2.Cb6 + consFvKc2.Cb7 + consFvKc2.Cb8,
            ConsumptionFvCpsPpk = consFvCpsPpk,
            ConsKgCpsPpkSum = consFvCpsPpk.Pko + consFvCpsPpk.Spo + data1.ConsKgUvtp,
            ConsKgMk = ConsKgCb.Cb5 + ConsKgCb.Cb6 + ConsKgCb.Cb7 + ConsKgCb.Cb8 + consFvCpsPpk.Pko + consFvCpsPpk.Spo + data1.ConsKgUvtp,
            ConsFvCpsPpkSum = Math.Round((consFvCpsPpk.Pko + consFvCpsPpk.Spo + data1.ConsKgUvtp) / KpeDry * GasConstants.ConsFvC, 10),
            ConsGsuf = consGsuf,
            TradeGasChmk = Math.Round(tec.ChmkTecSum * 1000, 10),
         };
      }
   }
}
