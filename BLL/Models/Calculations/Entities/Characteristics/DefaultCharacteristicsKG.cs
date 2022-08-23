using BLL.Interfaces.BaseCalculations;
using BLL.Interfaces.BaseCalculations.Density;
using BLL.Interfaces.Calculations.Characteristics;
using BLL.Models.BaseModels.Characteristics.Gas;
using DA.Entities;
using DA.Entities.Characteristics;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Calculations.Entities.Characteristics
{
   public class DefaultCharacteristicsKG : ICalcCharacteristicsKg
   {
      private IQn<KG> Qn;
      private IDensity<KG> Density;
      public DefaultCharacteristicsKG(IQn<KG> qn, IDensity<KG> density)
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
