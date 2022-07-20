using Business.DTO.Models.Characteristics.Gas;
using DataAccess.Entities;
using System.Collections.Generic;

namespace Business.Interfaces.Calculations
{
   public interface ICalcCharacteristicsKg 
   {
      IEnumerable<CharacteristicsKG> CalcEntities(IEnumerable<CharacteristicsKgAll> _kgs);
      CharacteristicsKG CalcEntity(CharacteristicsKgAll kg);
   }
}
