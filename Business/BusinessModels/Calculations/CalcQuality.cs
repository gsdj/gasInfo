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
   public class CalcQuality : ICalcQuality
   {
      public IEnumerable<QualityDTO> CalcEntities(IEnumerable<QualityAll> qualityAll, IEnumerable<CharacteristicsKgDTO> charKgs)
      {
         List<QualityDTO> qDTO = new List<QualityDTO>(qualityAll.Count());

         var data =
            from t1q in qualityAll
            join t2charKg in charKgs on new { t1q.Date } equals new { t2charKg.Date }
            select new
            {
               Quality = t1q,
               CharKg = t2charKg
            };

         foreach (var item in data)
         {
            qDTO.Add(CalcEntity(item.Quality, item.CharKg));
         }
         return qDTO;
      }

      public QualityDTO CalcEntity(QualityAll quality, CharacteristicsKgDTO charKg)
      {
         return new QualityDTO
         {
            Date = quality.Date,
            Kc1 =
            {
               W = quality.Kc1.W,
               A = quality.Kc1.A,
               V = quality.Kc1.V,
               Vc = Vc(quality.Kc1.V, quality.Kc1.A),
               KgFv = KgFv(quality.Kc1.V, quality.Kc1.A, quality.Kc1.W),
               KgFh = KgFh(quality.Kc1.V, quality.Kc1.A, quality.Kc1.W, charKg.Kc1.Density),
               Density = charKg.Kc1.Density,
            },
            Kc2 =
            {
               W = quality.Kc2.W,
               A = quality.Kc2.A,
               V = quality.Kc2.V,
               Vc = Vc(quality.Kc2.V, quality.Kc2.A),
               KgFv = KgFv(quality.Kc2.V, quality.Kc2.A, quality.Kc2.W),
               KgFh = KgFh(quality.Kc2.V, quality.Kc2.A, quality.Kc2.W, charKg.Kc2.Density),
               Density = charKg.Kc2.Density,
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
