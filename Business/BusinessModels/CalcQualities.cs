using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.Interfaces.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessModels
{
   public class CalcQualities
   {
      ICalculation<QualityDTO> Calc;
      public CalcQualities (ICalculation<QualityDTO> calc)
      {
         Calc = calc;
      }

      public IEnumerable<QualityDTO> CalcEntities(Data Data)
      {
         var data = Data as QualityDataList;
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
            qualities.Add(Calc.CalcEntity(item));
         }
         return qualities;
      }
   }
}
