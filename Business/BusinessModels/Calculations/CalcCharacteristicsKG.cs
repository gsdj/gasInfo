using Business.DTO.Models.Characteristics;
using Business.DTO.Models.Characteristics.Gas;
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
      public CalcCharacteristicsKG(IQn<KG> qn, IDensity<KG> density)
      {
         Qn = qn;
         Density = density;
      }
      public IEnumerable<CharacteristicsKG> CalcEntities(IEnumerable<CharacteristicsKgAll> _kgs)
      {
         List<CharacteristicsKG> KgDTOList = new List<CharacteristicsKG>(_kgs.Count());
         foreach (var item in _kgs)
         {
            KgDTOList.Add(CalcEntity(item));
         }
         return KgDTOList;
      }

      public CharacteristicsKG CalcEntity(CharacteristicsKgAll kg)
      {
         return new CharacteristicsKG
         {
            Date = kg.Date,
            Kc1 =
            {
               Qn = Qn.Calc(kg.Kc1),
               Density = Density.Calc(kg.Kc1),
            },
            Kc2 =
            {
               Qn = Qn.Calc(kg.Kc2),
               Density = Density.Calc(kg.Kc2),
            }
         };
      }
   }
}
