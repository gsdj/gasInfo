using Business.BusinessModels.BaseCalculations.Consumption;
using Business.DTO;
using Business.DTO.General;
using Business.Interfaces.BaseCalculations.Consumption;
using Business.Interfaces.Calculations;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.BusinessModels.Calculations
{
   public class CalcEbChmk : ICalcEbChmk
   {
      private IChargeConsFV<DefaultChargeConsFV> ChargeConsFV;
      private ICalcDgPgChmkEb DgPgChmkEb;
      public CalcEbChmk(ICalcDgPgChmkEb calceb, IChargeConsFV<DefaultChargeConsFV> consfv)
      {
         DgPgChmkEb = calceb;
         ChargeConsFV = consfv;
      }

      public IEnumerable<EbChmkDTO> CalcEntities(IEnumerable<AmmountCb> cbs, IEnumerable<DgPgChmkEb> dgpgs)
      {
         List<EbChmkDTO> ebDTO = new List<EbChmkDTO>(dgpgs.Count());

         foreach (var item in dgpgs)
         {
            var prod2 = cbs.Where(p => p.Date <= item.Date);

            ebDTO.Add(CalcEntity(prod2, item));
         }
         return ebDTO;
      }

      public EbChmkDTO CalcEntity(IEnumerable<AmmountCb> cb, DgPgChmkEb dgpg)
      {
         DgPgChmkEbDTO dgPgChmkEbDTO = DgPgChmkEb.CalcEntity(dgpg);

         var ConsumptionFv = cb.Select(p => new CbAll
         { 
            Kc1 =
            {
               Cb1 = ChargeConsFV.Calc(p.Cb1, p.OutputMultipliers.Cb1, p.OutputMultipliers.Fv),
               Cb2 = ChargeConsFV.Calc(p.Cb2, p.OutputMultipliers.Cb2, p.OutputMultipliers.Fv),
               Cb3 = ChargeConsFV.Calc(p.Cb3, p.OutputMultipliers.Cb3, p.OutputMultipliers.Fv),
               Cb4 = ChargeConsFV.Calc(p.Cb4, p.OutputMultipliers.Cb4, p.OutputMultipliers.Fv),
            },
            Kc2 =
            {
               Cb1 = ChargeConsFV.Calc(p.Cb5, p.OutputMultipliers.Cb5, p.OutputMultipliers.Fv),
               Cb2 = ChargeConsFV.Calc(p.Cb6, p.OutputMultipliers.Cb6, p.OutputMultipliers.Fv),
               Cb3 = ChargeConsFV.Calc(p.Cb7, p.OutputMultipliers.Cb7, p.OutputMultipliers.Fv),
               Cb4 = ChargeConsFV.Calc(p.Cb8, p.OutputMultipliers.Cb8, p.OutputMultipliers.Fv),
            },
         });

         decimal sumCb1 = ConsumptionFv.Sum(p => p.Kc1.Cb1);
         decimal sumCb2 = ConsumptionFv.Sum(p => p.Kc1.Cb2);
         decimal sumCb3 = ConsumptionFv.Sum(p => p.Kc1.Cb3);
         decimal sumCb4 = ConsumptionFv.Sum(p => p.Kc1.Cb4);
         decimal sumKc1 = sumCb1 + sumCb2 + sumCb3 + sumCb4;
         decimal sumGru = sumKc1 + ConsumptionFv.Sum(p => p.Kc2.Cb1 + p.Kc2.Cb2 + p.Kc2.Cb3 + p.Kc2.Cb4);

         return new EbChmkDTO
         {
            Date = dgPgChmkEbDTO.Date,
            ConsumptionKc1 =
            {
               Cb1 = dgPgChmkEbDTO.ConsumptionDgKc1.Cb1,
               Cb2 = dgPgChmkEbDTO.ConsumptionDgKc1.Cb1,
               Cb3 = dgPgChmkEbDTO.ConsumptionDgKc1.Cb1,
               Cb4 = dgPgChmkEbDTO.ConsumptionDgKc1.Cb1,
            },
            ConsDgKc1Sum = dgPgChmkEbDTO.ConsDgKc1Sum,
            UdConsumptionKc1 =
            {
               Cb1 = (dgPgChmkEbDTO.ConsumptionDgKc1.Cb1 == 0) ? 0 : Math.Round((dgPgChmkEbDTO.ConsumptionDgKc1.Cb1 * GasConstants.UdDgC) / sumCb1, MidpointRounding.ToEven),
               Cb2 = (dgPgChmkEbDTO.ConsumptionDgKc1.Cb2 == 0) ? 0 : Math.Round((dgPgChmkEbDTO.ConsumptionDgKc1.Cb2 * GasConstants.UdDgC) / sumCb2, MidpointRounding.ToEven),
               Cb3 = (dgPgChmkEbDTO.ConsumptionDgKc1.Cb3 == 0) ? 0 : Math.Round((dgPgChmkEbDTO.ConsumptionDgKc1.Cb3 * GasConstants.UdDgC) / sumCb3, MidpointRounding.ToEven),
               Cb4 = (dgPgChmkEbDTO.ConsumptionDgKc1.Cb4 == 0) ? 0 : Math.Round((dgPgChmkEbDTO.ConsumptionDgKc1.Cb4 * GasConstants.UdDgC) / sumCb4, MidpointRounding.ToEven),
            },
            UdConsKc1Sum = (dgPgChmkEbDTO.ConsDgKc1Sum == 0) ? 0 : (int)Math.Round((dgPgChmkEbDTO.ConsDgKc1Sum * GasConstants.UdDgC) / sumKc1, MidpointRounding.ToEven),
            ConsumptionGru =
            {
               Gru1 = dgPgChmkEbDTO.ConsumptionPgGru.Gru1,
               Gru2 = dgPgChmkEbDTO.ConsumptionPgGru.Gru2,
            },
            ConsPgUpc = dgPgChmkEbDTO.ConsPgUpc,
            UdConsumptionGru =
            {
               Gru1 = Math.Round((dgPgChmkEbDTO.ConsumptionPgGru.Gru1 == 0) ? 0 : (dgPgChmkEbDTO.ConsumptionPgGru.Gru1 * GasConstants.UdPgC) / (sumGru * 0.4m), 2),
               Gru2 = Math.Round((dgPgChmkEbDTO.ConsumptionPgGru.Gru2 == 0) ? 0 : (dgPgChmkEbDTO.ConsumptionPgGru.Gru2 * GasConstants.UdPgC) / (sumGru * 0.6m), 2),
            },
         };
      }
   }
}
