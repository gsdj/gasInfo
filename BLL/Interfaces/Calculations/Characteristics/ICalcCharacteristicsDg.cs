using BLL.Models.BaseModels.Characteristics.Gas;
using DA.Entities;
using System.Collections.Generic;

namespace BLL.Interfaces.Calculations.Characteristics
{
   public interface ICalcCharacteristicsDg
   {
      IEnumerable<CharacteristicsDG> CalcEntities(IEnumerable<CharacteristicsDgAll> _dgs);
      CharacteristicsDG CalcEntity(CharacteristicsDgAll dg);
   }
}
