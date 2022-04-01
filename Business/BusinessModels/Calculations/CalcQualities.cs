using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.DTO.Characteristics;
using Business.Interfaces;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.Calculations;
using DataAccess.Entities;
using DataAccess.Entities.Characteristics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.BusinessModels.Calculations
{
   public class CalcQualities : ICalcQuality, IKgFh, IKgFv, IVc
   {
      private IDensity<KG> Density;
      public CalcQualities(IDensity<KG> density)
      {
         Density = density;
      }

      public IEnumerable<QualityDTO> CalcEntities(IEnumerable<QualityAll> qual, IEnumerable<CharacteristicsKgAll> kgs)
      {
         var qualityData = from t1charKg in kgs
                           join t2qual in qual on new { t1charKg.Date } equals new { t2qual.Date }
                           select new
                           {
                              Kg = t1charKg,
                              Qualities = t2qual
                           };
         List<QualityDTO> qualities = new List<QualityDTO>(qualityData.Count());
         foreach (var item in qualityData)
         {
            qualities.Add(CalcEntity(item.Qualities, item.Kg));
         }
         return qualities;
      }

      public QualityDTO CalcEntity(QualityAll qual, CharacteristicsKgAll kg)
      {
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
               KgFh = KgFh(qual.Kc1.V, qual.Kc1.A, qual.Kc1.W, Density.Calc(kg.Kc1)),
               Density = Density.Calc(kg.Kc1),
            },
            Kc2 =
            {
               W = qual.Kc2.W,
               A = qual.Kc2.A,
               V = qual.Kc2.V,
               Vc = Vc(qual.Kc2.V, qual.Kc2.A),
               KgFv = KgFv(qual.Kc2.V, qual.Kc2.A, qual.Kc2.W),
               KgFh = KgFh(qual.Kc2.V, qual.Kc2.A, qual.Kc2.W, Density.Calc(kg.Kc2)),
               Density = Density.Calc(kg.Kc2),
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
         decimal result = Math.Round((GasConstants.PropC * (decimal)Math.Sqrt((double)Vc(V, A)) * ((100 - W) / 100)), 10);
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
