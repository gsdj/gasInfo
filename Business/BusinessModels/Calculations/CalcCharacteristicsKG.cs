using Business.DTO;
using Business.Interfaces.Calculations;
using DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Business.BusinessModels.Calculations
{
   public class CalcCharacteristicsKG : ICalcCharacteristicsKg
   {
      public IEnumerable<CharacteristicsKgDTO> CalcEntities(IEnumerable<CharacteristicsKgAll> _kgs)
      {
         List<CharacteristicsKgDTO> KgDTOList = new List<CharacteristicsKgDTO>(_kgs.Count());
         foreach (var item in _kgs)
         {
            KgDTOList.Add(CalcEntity(item));
         }
         return KgDTOList;
      }

      public CharacteristicsKgDTO CalcEntity(CharacteristicsKgAll kg)
      {
         return new CharacteristicsKgDTO
         {
            Date = kg.Date,
            Kc1 =
            {
               Components = 
               {
                  CO = kg.Kc1.CO,
                  CO2 = kg.Kc1.CO2,
                  H2 = kg.Kc1.H2,
                  N2 = kg.Kc1.N2,
                  CH4 = kg.Kc1.CH4,
                  CnHm = kg.Kc1.CnHm,
                  O2 = kg.Kc1.O2,
               },
               SumComponents = SumComponents(kg.Kc1.CO, kg.Kc1.CO2, kg.Kc1.H2, kg.Kc1.N2, kg.Kc1.CH4, kg.Kc1.CnHm, kg.Kc1.O2),
               Characteristics =
               {
                  Qn = Qn(kg.Kc1.CO, kg.Kc1.CnHm, kg.Kc1.CH4, kg.Kc1.H2),
                  Density = Density(kg.Kc1.CO2, kg.Kc1.O2, kg.Kc1.CO, kg.Kc1.CnHm, kg.Kc1.CH4, kg.Kc1.H2, kg.Kc1.N2),
               },
            },
            Kc2 =
            {
               Components =
               {
                  CO = kg.Kc2.CO,
                  CO2 = kg.Kc2.CO2,
                  H2 = kg.Kc2.H2,
                  N2 = kg.Kc2.N2,
                  CH4 = kg.Kc2.CH4,
                  CnHm = kg.Kc2.CnHm,
                  O2 = kg.Kc2.O2,
               },
               SumComponents = SumComponents(kg.Kc2.CO, kg.Kc2.CO2, kg.Kc2.H2, kg.Kc2.N2, kg.Kc2.CH4, kg.Kc2.CnHm, kg.Kc2.O2),
               Characteristics =
               {
                  Qn = Qn(kg.Kc2.CO, kg.Kc2.CnHm, kg.Kc2.CH4, kg.Kc2.H2),
                  Density = Density(kg.Kc2.CO2, kg.Kc2.O2, kg.Kc2.CO, kg.Kc2.CnHm, kg.Kc2.CH4, kg.Kc2.H2, kg.Kc2.N2),
               },
            }
         };
      }

      /// <summary>
      /// Плотность коксового газа
      /// </summary>
      /// <param name="CO2"></param>
      /// <param name="O2"></param>
      /// <param name="CO"></param>
      /// <param name="CnHm"></param>
      /// <param name="CH4"></param>
      /// <param name="H2"></param>
      /// <param name="N2"></param>
      /// <returns></returns>
      public decimal Density(decimal CO2, decimal O2, decimal CO, decimal CnHm, decimal CH4, decimal H2, decimal N2)
      {
         return (0.01m * (CO2 * 1.842m + O2 * 1.331m + CO * 1.165m + CnHm * 1.228m + CH4 * 0.6679m + H2 * 0.0837m + N2 * 1.166m));
      }

      /// <summary>
      /// Калорийность коксового газа
      /// </summary>
      /// <param name="CO"></param>
      /// <param name="CnHm"></param>
      /// <param name="CH4"></param>
      /// <param name="H2"></param>
      /// <returns></returns>
      public decimal Qn(decimal CO, decimal CnHm, decimal CH4, decimal H2)
      {
         return (0.01m * (CO * 2810 + CnHm * 14540 + CH4 * 7970 + H2 * 2400));
      }

      /// <summary>
      /// Сумма компонентов состава
      /// </summary>
      /// <param name="components"></param>
      /// <returns></returns>
      public decimal SumComponents(params decimal[] components)
      {
         decimal result = 0;
         foreach (var item in components)
         {
            result += item;
         }
         return result;
      }
   }
}
