using BLL.Models.BaseModels.Characteristics.Gas;
using DA.Entities;
using System.Collections.Generic;

namespace BLL.Interfaces.Calculations.Characteristics
{
   public interface ICalcCharacteristicsKg 
   {
      IEnumerable<CharacteristicsKG> CalcEntities(IEnumerable<CharacteristicsKgAll> _kgs);
      CharacteristicsKG CalcEntity(CharacteristicsKgAll kg);
   }
}
