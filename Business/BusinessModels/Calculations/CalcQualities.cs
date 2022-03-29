using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.DTO.Characteristics;
using Business.Interfaces;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.Calculations;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.BusinessModels.Calculations
{
   public class CalcQualities : ICalculations<QualityDTO>, ICalculation<QualityDTO>, IKgFh, IKgFv, IVc
   {
      //private IConstantsAll _cAll;
      private Dictionary<int, SteamCharacteristicsDTO> _steam;
      public CalcQualities(ISteamCharacteristicsService st)
      {
         _steam = st.GetCharacteristics();
      }
      public IEnumerable<QualityDTO> CalcEntities(EnumerableData Data)
      {
         var data = Data as QualityEnumData;
         var charKg = data.Kg;
         var quality = data.Qualities;

         var qualityData = from t1charKg in charKg
                           join t2qual in quality on new { t1charKg.Date } equals new { t2qual.Date }
                           select new QualityData
                           {
                              Kg = t1charKg,
                              Qualities = t2qual
                           };
         List<QualityDTO> qualities = new List<QualityDTO>(qualityData.Count());
         foreach (var item in qualityData)
         {
            qualities.Add(CalcEntity(item));
         }
         return qualities;
      }

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
