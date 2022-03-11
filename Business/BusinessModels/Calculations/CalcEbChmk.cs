using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.Interfaces.Calculations;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessModels.Calculations
{
   public class CalcEbChmk : ICalculation<EbChmkDTO>// ICalcEbChmk
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
         decimal sumCb1 = prod.Sum(p => p.ConsumptionFvKc1.Cb1);
         decimal sumCb2 = prod.Sum(p => p.ConsumptionFvKc1.Cb2);
         decimal sumCb3 = prod.Sum(p => p.ConsumptionFvKc1.Cb3);
         decimal sumCb4 = prod.Sum(p => p.ConsumptionFvKc1.Cb4);
         decimal sumKc1 = sumCb1 + sumCb2 + sumCb3 + sumCb4;
         decimal sumGru = sumKc1 + prod.Sum(p => p.ConsumptionFvKc2.Cb5 + p.ConsumptionFvKc2.Cb6 + p.ConsumptionFvKc2.Cb7 + p.ConsumptionFvKc2.Cb8);

         return new EbChmkDTO
         { 
            Date = eb.Date,
            ConsumptionKc1 = 
            {
               Cb1 = eb.ConsumptionDgKc1.Cb1,
               Cb2 = eb.ConsumptionDgKc1.Cb1,
               Cb3 = eb.ConsumptionDgKc1.Cb1,
               Cb4 = eb.ConsumptionDgKc1.Cb1,
            },
            ConsDgKc1Sum = eb.ConsDgKc1Sum,
            UdConsumptionKc1 =
            {
               Cb1 = (eb.ConsumptionDgKc1.Cb1 == 0) ? 0 : (int)Math.Round((eb.ConsumptionDgKc1.Cb1 * Constants.UdDgC) / sumCb1, MidpointRounding.ToEven),
               Cb2 = (eb.ConsumptionDgKc1.Cb2 == 0) ? 0 : (int)Math.Round((eb.ConsumptionDgKc1.Cb2 * Constants.UdDgC) / sumCb2, MidpointRounding.ToEven),
               Cb3 = (eb.ConsumptionDgKc1.Cb3 == 0) ? 0 : (int)Math.Round((eb.ConsumptionDgKc1.Cb3 * Constants.UdDgC) / sumCb3, MidpointRounding.ToEven),
               Cb4 = (eb.ConsumptionDgKc1.Cb4 == 0) ? 0 : (int)Math.Round((eb.ConsumptionDgKc1.Cb4 * Constants.UdDgC) / sumCb4, MidpointRounding.ToEven),
            },
            UdConsKc1Sum = (eb.ConsDgKc1Sum == 0) ? 0 : (int)Math.Round((eb.ConsDgKc1Sum * Constants.UdDgC) / sumKc1, MidpointRounding.ToEven),
            ConsumptionGru =
            {
               Gru1 = eb.ConsumptionPgGru.Gru1,
               Gru2 = eb.ConsumptionPgGru.Gru2,
            },
            ConsPgUpc = eb.ConsPgUpc,
            UdConsumptionGru =
            {
               Gru1 = Math.Round((eb.ConsumptionPgGru.Gru1 == 0) ? 0 : (eb.ConsumptionPgGru.Gru1 * Constants.UdPgC) / (sumGru * 0.4m), 2),
               Gru2 = Math.Round((eb.ConsumptionPgGru.Gru2 == 0) ? 0 : (eb.ConsumptionPgGru.Gru2 * Constants.UdPgC) / (sumGru * 0.6m), 2),
            },
         };
      }

      public EbChmkDTO CalcEntity(Data data)
      {
         throw new NotImplementedException();
      }
   }
}
