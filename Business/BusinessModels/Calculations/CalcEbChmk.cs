using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.Interfaces;
using Business.Interfaces.Calculations;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.BusinessModels.Calculations
{
   public class CalcEbChmk : ICalculation<EbChmkDTO>, ICalculations<EbChmkDTO>
   {
      private IConstantsAll _cAll;
      private Constants Constants;
      public CalcEbChmk(IConstantsAll cAll)
      {
         _cAll = cAll;
         Constants = _cAll.GetConstants();
      }

      public IEnumerable<EbChmkDTO> CalcEntities(EnumerableData data)
      {
         var Data = data as EbChmkEnumData;

         List<EbChmkDTO> ebDTO = new List<EbChmkDTO>(Data.DgPgChmkEb.Count());

         foreach (var item in Data.DgPgChmkEb)
         {
            var prod2 = Data.Production.Where(p => p.Date <= item.Date);

            EbChmkData ebData = new EbChmkData
            {
               DgPgChmkEb = item,
               Production = prod2,
            };

            ebDTO.Add(CalcEntity(ebData));
         }
         return ebDTO;
      }

      public EbChmkDTO CalcEntity(Data data)
      {
         var Data = data as EbChmkData;
         var prod = Data.Production;
         var eb = Data.DgPgChmkEb;

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
   }
}
