using Business.DTO;
using Business.Interfaces;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Calculations
{
   public interface ICalcCharacteristicsDg
   {
      IEnumerable<CharacteristicsDgDTO> CalcEntities(IEnumerable<CharacteristicsDgAll> _dgs);
      CharacteristicsDgDTO CalcEntity(CharacteristicsDgAll dg);
   }
}
