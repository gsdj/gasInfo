using Business.DTO;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.BaseCalculations.Density;
using Business.Interfaces.Calculations;
using DataAccess.Entities;
using DataAccess.Entities.Characteristics;
using System.Collections.Generic;
using System.Linq;

namespace Business.BusinessModels.Calculations
{
   public class CalcCharacteristicsKG : ICalcCharacteristicsKg
   {
      private IQn<KG> Qn;
      private IDensity<KG> Density;
      private ISumComponents SumComponents;
      public CalcCharacteristicsKG(IQn<KG> qn, IDensity<KG> density, ISumComponents sum)
      {
         Qn = qn;
         Density = density;
         SumComponents = sum;
      }
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
               SumComponents = SumComponents.Calc(kg.Kc1.CO, kg.Kc1.CO2, kg.Kc1.H2, kg.Kc1.N2, kg.Kc1.CH4, kg.Kc1.CnHm, kg.Kc1.O2),
               Characteristics =
               {
                  Qn = Qn.Calc(kg.Kc1),
                  Density = Density.Calc(kg.Kc1),
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
               SumComponents = SumComponents.Calc(kg.Kc2.CO, kg.Kc2.CO2, kg.Kc2.H2, kg.Kc2.N2, kg.Kc2.CH4, kg.Kc2.CnHm, kg.Kc2.O2),
               Characteristics =
               {
                  Qn = Qn.Calc(kg.Kc2),
                  Density = Density.Calc(kg.Kc2),
               },
            }
         };
      }
   }
}
