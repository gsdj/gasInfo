using Business.DTO.Models.Characteristics.Gas;
using DataAccess.Entities;
using System.Collections.Generic;

namespace Business.Interfaces.Calculations
{
   public interface ICalcCharacteristicsDg
   {
      IEnumerable<CharacteristicsDG> CalcEntities(IEnumerable<CharacteristicsDgAll> _dgs);
      CharacteristicsDG CalcEntity(CharacteristicsDgAll dg);
   }
}
