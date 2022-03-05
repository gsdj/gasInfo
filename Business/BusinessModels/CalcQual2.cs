using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.Interfaces.Calculations;
using System;

namespace Business.BusinessModels
{
   public class CalcQual2 : ICalculations<QualityDTO>
   {
      public QualityDTO CalcEntity(Data data)
      {
         var Data = data as QualityData;
         var qual = Data.Qualities;
         var kg = Data.Kg;
         return new QualityDTO
         {
            Date = qual.Date,
            Kc1 =
            {
               W = qual.Kc1.W,
               A = qual.Kc1.A,
               V = qual.Kc1.V,
               Vc = Vc(qual.Kc1.V, qual.Kc1.A),
               KgFv = KgFv(qual.Kc1.V, qual.Kc1.A, qual.Kc1.W),
               KgFh = KgFh(qual.Kc1.V, qual.Kc1.A, qual.Kc1.W, kg.Kc1.Characteristics.Density),
               Density = kg.Kc1.Characteristics.Density,
            },
            Kc2 =
            {
               W = qual.Kc2.W,
               A = qual.Kc2.A,
               V = qual.Kc2.V,
               Vc = Vc(qual.Kc2.V, qual.Kc2.A),
               KgFv = KgFv(qual.Kc2.V, qual.Kc2.A, qual.Kc2.W),
               KgFh = KgFh(qual.Kc2.V, qual.Kc2.A, qual.Kc2.W, kg.Kc2.Characteristics.Density),
               Density = kg.Kc2.Characteristics.Density,
            }
         };
      }
      public decimal KgFh(decimal V, decimal A, decimal W, decimal density)
      {
         decimal Fv = KgFv(V, A, W);

         if (density == 0 || Fv == 0)
            return 0;

         decimal result = Math.Round((Fv / density / 100), 10);
         return result;
      }

      public decimal KgFv(decimal V, decimal A, decimal W)
      {
         decimal result = Math.Round((Constants.propC * (decimal)Math.Sqrt((double)Vc(V, A)) * ((100 - W) / 100)), 10);
         return result;
      }

      public decimal Vc(decimal V, decimal A)
      {
         if (V == 0)
            return 0;

         decimal result = Math.Round((V * ((100 - A) / 100)), 10);
         return result;
      }
   }
}
