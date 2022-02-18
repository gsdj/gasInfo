using Business.DTO;
using Business.Interfaces.Calculations;
using Bussiness.BusinessModels;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessModels.Calculations
{
   public class CalcEbChmk : ICalcEbChmk
   {
      public IEnumerable<EbChmkDTO> CalcEntities(IEnumerable<ProductionDTO> prod, IEnumerable<DgPgChmkEbDTO> dgpgChmkEbs)
      {
         List<EbChmkDTO> ebDTO = new List<EbChmkDTO>(dgpgChmkEbs.Count());
         foreach (var item in dgpgChmkEbs)
         {
            var prod2 = prod.Where(p => p.Date <= item.Date);
            ebDTO.Add(CalcEntity(prod2, item));
         }
         return ebDTO;
      }

      public EbChmkDTO CalcEntity(IEnumerable<ProductionDTO> prod, DgPgChmkEbDTO eb)
      {
         decimal sumCb1 = prod.Sum(p => p.Cb1ConsFv);
         decimal sumCb2 = prod.Sum(p => p.Cb2ConsFv);
         decimal sumCb3 = prod.Sum(p => p.Cb3ConsFv);
         decimal sumCb4 = prod.Sum(p => p.Cb4ConsFv);
         decimal sumGru = (sumCb1 + sumCb2 + sumCb3 + sumCb4) + prod.Sum(p => p.Cb5ConsFv + p.Cb6ConsFv + p.Cb7ConsFv + p.Cb8ConsFv);

         return new EbChmkDTO
         { 
            Date = eb.Date,
            ConsDgCb1 = eb.ConsDgCb1,
            ConsDgCb2 = eb.ConsDgCb1,
            ConsDgCb3 = eb.ConsDgCb1,
            ConsDgCb4 = eb.ConsDgCb1,
            UdConsCb1 = (eb.ConsDgCb1 == 0) ? 0 : (int)Math.Round((eb.ConsDgCb1 * Constants.UdDgC) / sumCb1, MidpointRounding.ToEven),
            UdConsCb2 = (eb.ConsDgCb2 == 0) ? 0 : (int)Math.Round((eb.ConsDgCb2 * Constants.UdDgC) / sumCb2, MidpointRounding.ToEven),
            UdConsCb3 = (eb.ConsDgCb3 == 0) ? 0 : (int)Math.Round((eb.ConsDgCb3 * Constants.UdDgC) / sumCb3, MidpointRounding.ToEven),
            UdConsCb4 = (eb.ConsDgCb4 == 0) ? 0 : (int)Math.Round((eb.ConsDgCb4 * Constants.UdDgC) / sumCb4, MidpointRounding.ToEven),
            UdConsKc1 = (eb.ConsDgKc1 == 0) ? 0 : (int)Math.Round((eb.ConsDgKc1 * Constants.UdDgC) / (sumCb1 + sumCb2 + sumCb3 + sumCb4), MidpointRounding.ToEven),
            ConsPgGru1 = eb.ConsPgGru1,
            ConsPgGru2 = eb.ConsPgGru2,
            ConsPgUpc = eb.ConsPgUpc,
            UdConsGru1 = Math.Round((eb.ConsPgGru1 == 0) ? 0 : (eb.ConsPgGru1 * Constants.UdPgC) / (sumGru * 0.4m), 2),
            UdConsGru2 = Math.Round((eb.ConsPgGru2 == 0) ? 0 : (eb.ConsPgGru2 * Constants.UdPgC) / (sumGru * 0.6m), 2),
         };
      }
   }
}
