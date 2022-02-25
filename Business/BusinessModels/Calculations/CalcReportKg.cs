using Business.DTO;
using Business.DTO.Consumption;
using Business.Interfaces.Calculations;
using Bussiness.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessModels.Calculations
{
   public class CalcReportKg : ICalcReportKg
   {
      public IEnumerable<ReportKgDTO> CalcEntities(IEnumerable<ProductionDTO> prod, IEnumerable<ConsumptionKgDTO> consKg, 
                                                   IEnumerable<DevicesKipDTO> kips, IEnumerable<CharacteristicsKgDTO> charKgs, 
                                                   IEnumerable<OutputKgDTO> outputKg, IEnumerable<TecDTO> tec)
      {
         List<ReportKgDTO> reportKgDTO = new List<ReportKgDTO>(prod.Count());
         var data =
            from t1prod in prod
            join t2kip in kips on new { t1prod.Date } equals new { t2kip.Date }
            join t3charKg in charKgs on new { t2kip.Date } equals new { t3charKg.Date }
            join t4consKg in consKg on new { t3charKg.Date } equals new { t4consKg.Date }
            join t5outputKg in outputKg on new { t4consKg.Date } equals new { t5outputKg.Date }
            join t6tec in tec on new { t5outputKg.Date } equals new { t6tec.Date }
            select new
            {
               Prod = t1prod,
               Kip = t2kip,
               CharKg = t3charKg,
               ConsKg = t4consKg,
               OutputKg = t5outputKg,
               Tec= t6tec
            };
         foreach (var item in data)
         {
            reportKgDTO.Add(CalcEntity(item.Prod, item.ConsKg, item.OutputKg, item.Kip, item.CharKg, item.Tec));
         }
         return reportKgDTO;
      }

      public ReportKgDTO CalcEntity(ProductionDTO prod, ConsumptionKgDTO consKg, OutputKgDTO outputKg,
                                    DevicesKipDTO kip, CharacteristicsKgDTO charKg, TecDTO tec)
      {
         var consKc2 = new ConsumptionKc2<decimal>
         {
            Cb5 = Math.Round(consKg.ConsumptionCb.Cb5),
            Cb6 = Math.Round(consKg.ConsumptionCb.Cb6),
            Cb7 = Math.Round(consKg.ConsumptionCb.Cb7),
            Cb8 = Math.Round(consKg.ConsumptionCb.Cb8),
         };

         var consCpsPpk = new ConsumptionCpsPpk
         {
            Spo = Math.Round(consKg.ConsumptionCpsPpk.Spo),
            Pko = Math.Round(consKg.QcRcCpsPpk.Pko.Value * charKg.Kc1.Characteristics.Qn / 4000),
         };

         var consFvKc2 = new ConsumptionKc2<decimal>
         {
            Cb5 = UdConsKgFv(consKg.ConsumptionCb.Cb5, prod.ConsumptionFvKc2.Cb5),
            Cb6 = UdConsKgFv(consKg.ConsumptionCb.Cb6, prod.ConsumptionFvKc2.Cb6),
            Cb7 = UdConsKgFv(consKg.ConsumptionCb.Cb7, prod.ConsumptionFvKc2.Cb7),
            Cb8 = UdConsKgFv(consKg.ConsumptionCb.Cb8, prod.ConsumptionFvKc2.Cb8),
         };

         var data = new
         {
            SumKgCbsSpoGsuf = consKg.ConsumptionCb.Cb5 + consKg.ConsumptionCb.Cb6 + consKg.ConsumptionCb.Cb7 + consKg.ConsumptionCb.Cb8 + consCpsPpk.Spo + consKg.ConsumptionGsuf,
            ConsKgUvtp = consKg.QcRcCpsPpk.Uvtp == 0 || charKg.Kc1.Characteristics.Qn == 0 ? 0 :
                        Math.Round(consKg.QcRcCpsPpk.Uvtp * charKg.Kc1.Characteristics.Qn / 4000, 10),

            OutKgDryPkp = Math.Round((prod.KpeDry * prod.KpeC) / prod.KpeDry, 10),
            OutKgPko = Math.Round(prod.KpeDry * prod.KpeC, 10),
         };

         var data2 = new
         {
            TradeGasChmk = Math.Round(tec.ChmkTecSum * 1000, 10),
            OutKgMk = Math.Round((data.SumKgCbsSpoGsuf + consCpsPpk.Pko + data.ConsKgUvtp) + (tec.ChmkTecSum * 1000), 10),
            KipSpr = Math.Round(outputKg.PrMk4000 + consCpsPpk.Pko + data.ConsKgUvtp, 10),
            OutKgCb18 = ((data.SumKgCbsSpoGsuf + consCpsPpk.Pko + data.ConsKgUvtp) + (tec.ChmkTecSum * 1000)) - data.OutKgPko,
            ConsFvPko = Math.Round((consCpsPpk.Pko + data.ConsKgUvtp) / prod.KpeDry * Constants.consFvC, 10),
            ConsFvCpsPpk = Math.Round((consCpsPpk.Spo + consCpsPpk.Pko + data.ConsKgUvtp) / prod.SpoPerKus * Constants.consFvC, 10),

            OutKgCb16 = (prod.Cb1Cb6 == 0 || prod.MK == 0) ? 0 :
                        (((data.SumKgCbsSpoGsuf + consCpsPpk.Pko + data.ConsKgUvtp) +
                        (tec.ChmkTecSum * 1000)) - data.OutKgPko) * prod.Cb1Cb6 / prod.MK,

            OutKgCb78 = (prod.Cb7Cb8 == 0 || prod.MK == 0) ? 0 :
                        (((data.SumKgCbsSpoGsuf + consCpsPpk.Pko + data.ConsKgUvtp) +
                        (tec.ChmkTecSum * 1000)) - data.OutKgPko) * prod.Cb7Cb8 / prod.MK,
         };

         var consFvCpsPpk = new ConsumptionCpsPpk
         {
            Spo = UdConsKgFv(consKg.ConsumptionCpsPpk.Spo, prod.SpoPerKus),
            Pko = Math.Round((consKg.ConsumptionCpsPpk.Pko + data.ConsKgUvtp) / prod.KpeDry * Constants.consFvC, 10),
         };

         return new ReportKgDTO
         {
            Date = prod.Date,
            OutKgPko = data.OutKgPko,
            OutKgCb16 = data2.OutKgCb16,
            OutKgCb78 = data2.OutKgCb78,
            OutKgCb18 = data2.OutKgCb18,
            OutKgMk = data2.OutKgMk,
            KipSpr = data2.KipSpr,
            OutKgDryPkp = data.OutKgDryPkp,
            OutKgDryCb16 = (prod.Cb1Cb6 == 0 || prod.MK == 0 || prod.Cb16ConsDry == 0) ? 0 : Math.Round(data2.OutKgCb16 / prod.Cb16ConsDry, 10),
            OutKgDryCb78 = (prod.Cb7Cb8 == 0 || prod.MK == 0 || prod.Cb78ConsDry == 0) ? 0 : Math.Round(data2.OutKgCb78 / prod.Cb78ConsDry, 10),
            OutKgDryMk = (data2.OutKgCb18 == 0 || prod.TnConsDry == 0) ? 0 : Math.Round(data2.OutKgCb18 / prod.TnConsDry, 10),
            ConsumptionKc2 = consKc2,
            ConsKgKc2Sum = consKc2.Cb5 + consKc2.Cb6 + consKc2.Cb7 + consKc2.Cb8,
            ConsumptionCpsPpk = consCpsPpk, 
            ConsKgUvtp = data.ConsKgUvtp,
            ConsumptionFvKc2 = consFvKc2,
            ConsFvKc2Sum = consFvKc2.Cb5 + consFvKc2.Cb6 + consFvKc2.Cb7 + consFvKc2.Cb8,
            ConsumptionFvCpsPpk = consFvCpsPpk,
            ConsKgCpsPpkSum = consFvCpsPpk.Pko + consFvCpsPpk.Spo + data.ConsKgUvtp,
            ConsKgMk = consKc2.Cb5 + consKc2.Cb6 + consKc2.Cb7 + consKc2.Cb8 + consFvCpsPpk.Pko + consFvCpsPpk.Spo + data.ConsKgUvtp,
            ConsFvCpsPpkSum = Math.Round((consFvCpsPpk.Pko + consFvCpsPpk.Spo + data.ConsKgUvtp) / prod.KpeDry * Constants.consFvC, 10),
            ConsGsuf = consKg.ConsumptionGsuf,
            TradeGasChmk = Math.Round(tec.ChmkTecSum * 1000, 10),
         };
         
      }

      public decimal UdConsKgFv(decimal consKg, decimal consKgFv)
      {
         if (consKg == 0 || consKgFv == 0)
            return 0;

         return Math.Round((consKg / consKgFv * Constants.consFvC), 10);
      }
   }
}
