using Business.DTO;
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
         var data = new
         {
            prod.KpeDry,
            prod.SpoPerKus,
            outputKg.PrMk4000,
            SumKgCbsSpoGsuf = consKg.Cb54000 + consKg.Cb64000 + consKg.Cb74000 + consKg.Cb84000 + consKg.Spo4000 + consKg.Gsuf4000,
            ConsKgCb5 = Math.Round(consKg.Cb54000),
            ConsKgCb6 = Math.Round(consKg.Cb64000),
            ConsKgCb7 = Math.Round(consKg.Cb74000),
            ConsKgCb8 = Math.Round(consKg.Cb84000),
            ConsKgSpo = Math.Round(consKg.Spo4000),
            ConsKgPkp = (consKg.QcRcPkcKs + consKg.QcRcPkcMs) == 0 || charKg.Kc1.Qn == 0 ? 0 :
                        Math.Round((consKg.QcRcPkcKs + consKg.QcRcPkcMs) * charKg.Kc1.Qn / 4000, 10),
            ConsKgUvtp = consKg.QcRcUvtp == 0 || charKg.Kc1.Qn == 0 ? 0 :
                        Math.Round(consKg.QcRcUvtp * charKg.Kc1.Qn / 4000, 10),
            ConsFvCb5 = UdConsKgFv(consKg.Cb54000, prod.Cb5ConsFv),
            ConsFvCb6 = UdConsKgFv(consKg.Cb64000, prod.Cb6ConsFv),
            ConsFvCb7 = UdConsKgFv(consKg.Cb74000, prod.Cb7ConsFv),
            ConsFvCb8 = UdConsKgFv(consKg.Cb84000, prod.Cb8ConsFv),
            ConsFvKc2 = UdConsKgFv(consKg.Cb54000 + consKg.Cb64000 + consKg.Cb74000 + consKg.Cb84000,
                                        prod.Cb5ConsFv + prod.Cb6ConsFv + prod.Cb7ConsFv + prod.Cb8ConsFv),

            ConsFvSpo = UdConsKgFv(consKg.Spo4000, prod.SpoPerKus),
            ConsGsuf = Math.Round(consKg.Gsuf4000, 10),
            CbsMk = prod.MK,
            Cbs16 = prod.Cb1Cb6,
            Cbs78 = prod.Cb7Cb8,
            Cb16ConsDry = Math.Round(prod.Cb16ConsDry, 10),
            Cb78ConsDry = Math.Round(prod.Cb78ConsDry, 10),
            TnConsDry = Math.Round(prod.TnConsDry, 10),
            OutKgDryPkp = Math.Round((prod.KpeDry * prod.KpeC) / prod.KpeDry, 10),
            OutKgPko = Math.Round(prod.KpeDry * prod.KpeC, 10),
         };

         var data2 = new
         {
            TradeGasChmk = Math.Round(tec.ChmkTecSum * 1000, 10),
            OutKgMk = Math.Round((data.SumKgCbsSpoGsuf + data.ConsKgPkp + data.ConsKgUvtp) + (tec.ChmkTecSum * 1000), 10),
            KipSpr = Math.Round(data.PrMk4000 + data.ConsKgPkp + data.ConsKgUvtp, 10),
            OutKgCb18 = ((data.SumKgCbsSpoGsuf + data.ConsKgPkp + data.ConsKgUvtp) + (tec.ChmkTecSum * 1000)) - data.OutKgPko,
            ConsFvPko = Math.Round((data.ConsKgPkp + data.ConsKgUvtp) / data.KpeDry * Constants.consFvC, 10),
            ConsFvCpsPpk = Math.Round((data.ConsKgSpo + data.ConsKgPkp + data.ConsKgUvtp) / data.SpoPerKus * Constants.consFvC, 10),

            OutKgCb16 = (data.Cbs16 == 0 || data.CbsMk == 0) ? 0 :
                        (((data.SumKgCbsSpoGsuf + data.ConsKgPkp + data.ConsKgUvtp) +
                        (tec.ChmkTecSum * 1000)) - data.OutKgPko) * data.Cbs16 / data.CbsMk,

            OutKgCb78 = (data.Cbs78 == 0 || data.CbsMk == 0) ? 0 :
                        (((data.SumKgCbsSpoGsuf + data.ConsKgPkp + data.ConsKgUvtp) +
                        (tec.ChmkTecSum * 1000)) - data.OutKgPko) * data.Cbs78 / data.CbsMk,
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
            OutKgDryCb16 = (data.Cbs16 == 0 || data.CbsMk == 0 || data.Cb16ConsDry == 0) ? 0 : Math.Round(data2.OutKgCb16 / data.Cb16ConsDry, 10),
            OutKgDryCb78 = (data.Cbs78 == 0 || data.CbsMk == 0 || data.Cb78ConsDry == 0) ? 0 : Math.Round(data2.OutKgCb78 / data.Cb78ConsDry, 10),
            OutKgDryMk = (data2.OutKgCb18 == 0 || data.TnConsDry == 0) ? 0 : Math.Round(data2.OutKgCb18 / data.TnConsDry, 10),
            ConsKgCb5 = data.ConsKgCb5,
            ConsKgCb6 = data.ConsKgCb6,
            ConsKgCb7 = data.ConsKgCb7,
            ConsKgCb8 = data.ConsKgCb8,
            ConsKgSpo = data.ConsKgSpo,
            ConsKgPkp = data.ConsKgPkp,
            ConsKgUvtp = data.ConsKgUvtp,
            ConsFvCb5 = data.ConsFvCb5,
            ConsFvCb6 = data.ConsFvCb6,
            ConsFvCb7 = data.ConsFvCb7,
            ConsFvCb8 = data.ConsFvCb8,
            ConsFvKc2 = data.ConsFvKc2,
            ConsFvSpo = data.ConsFvSpo,
            ConsFvPko = data.ConsFvSpo,
            ConsFvCpsPpk = data2.ConsFvCpsPpk,
            ConsGsuf = data.ConsGsuf,
            TradeGasChmk = data2.TradeGasChmk,
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
