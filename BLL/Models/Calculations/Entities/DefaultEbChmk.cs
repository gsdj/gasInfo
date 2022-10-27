using BLL.Constants;
using BLL.DTO;
using BLL.Interfaces.Calculations;
using BLL.Interfaces.Calculations.Production;
using DA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Calculations.Entities
{
   public class DefaultEbChmk : ICalcEbChmk
   {
      private ICokeCbConsumptionFvCalc CbFv;
      public DefaultEbChmk(ICokeCbConsumptionFvCalc cbFv)
      {
         CbFv = cbFv;
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
         var ConsumptionFv = CbFv.CalcEntities(cb);

         decimal sumCb1 = ConsumptionFv.Sum(p => p.Kc1.Cb1);
         decimal sumCb2 = ConsumptionFv.Sum(p => p.Kc1.Cb2);
         decimal sumCb3 = ConsumptionFv.Sum(p => p.Kc1.Cb3);
         decimal sumCb4 = ConsumptionFv.Sum(p => p.Kc1.Cb4);
         decimal sumKc1 = sumCb1 + sumCb2 + sumCb3 + sumCb4;
         decimal sumGru = sumKc1 + ConsumptionFv.Sum(p => p.Kc2.Sum);
         decimal consDgKc1Sum = dgpg.ConsDgCb1 + dgpg.ConsDgCb2 + dgpg.ConsDgCb3 + dgpg.ConsDgCb4;

         return new EbChmkDTO
         {
            Date = dgpg.Date,
            ConsumptionKc1 =
            {
               Cb1 = dgpg.ConsDgCb1,
               Cb2 = dgpg.ConsDgCb2,
               Cb3 = dgpg.ConsDgCb3,
               Cb4 = dgpg.ConsDgCb4,
            },
            ConsDgKc1Sum = consDgKc1Sum,
            UdConsumptionKc1 =
            {
               Cb1 = (dgpg.ConsDgCb1 == 0) ? 0 : Math.Round((dgpg.ConsDgCb1 * GasConstants.UdDgC) / sumCb1, MidpointRounding.ToEven),
               Cb2 = (dgpg.ConsDgCb2 == 0) ? 0 : Math.Round((dgpg.ConsDgCb2 * GasConstants.UdDgC) / sumCb2, MidpointRounding.ToEven),
               Cb3 = (dgpg.ConsDgCb3 == 0) ? 0 : Math.Round((dgpg.ConsDgCb3 * GasConstants.UdDgC) / sumCb3, MidpointRounding.ToEven),
               Cb4 = (dgpg.ConsDgCb4 == 0) ? 0 : Math.Round((dgpg.ConsDgCb4 * GasConstants.UdDgC) / sumCb4, MidpointRounding.ToEven),
            },
            UdConsKc1Sum = (consDgKc1Sum == 0) ? 0 : (int)Math.Round((consDgKc1Sum * GasConstants.UdDgC) / sumKc1, MidpointRounding.ToEven),
            ConsumptionGru =
            {
               Gru1 = dgpg.ConsPgGru1,
               Gru2 = dgpg.ConsPgGru2,
            },
            ConsPgUpc = dgpg.ConsPgGru1 + dgpg.ConsPgGru2,
            UdConsumptionGru =
            {
               Gru1 = Math.Round((dgpg.ConsPgGru1 == 0) ? 0 : (dgpg.ConsPgGru1 * GasConstants.UdPgC) / (sumGru * 0.4m), 2),
               Gru2 = Math.Round((dgpg.ConsPgGru2 == 0) ? 0 : (dgpg.ConsPgGru2 * GasConstants.UdPgC) / (sumGru * 0.6m), 2),
            },
         };
      }
   }
}
