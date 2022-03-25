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
   public interface ICalcCharacteristicsKg 
   {
      IEnumerable<CharacteristicsKgDTO> CalcEntities(IEnumerable<CharacteristicsKgAll> _kgs);
      CharacteristicsKgDTO CalcEntity(CharacteristicsKgAll kg);
      //decimal SumComponents(params decimal[] components);
      //decimal Qn(decimal CO, decimal CnHm, decimal CH4, decimal H2);
      //decimal Density(decimal CO2, decimal O2, decimal CO, decimal CnHm, decimal CH4, decimal H2, decimal N2);
   }
}
