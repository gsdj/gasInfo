using Business.DTO;
using Bussiness.Interfaces;
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
      decimal SumComponents(params decimal[] components);
      decimal Qn(decimal H2, decimal CO);
      decimal Density(decimal H2, decimal CO, decimal CO2, decimal N2);
      decimal AvgC(decimal componentA, decimal componentB);
      decimal AvgQn(decimal H2, decimal CO, decimal CO2, decimal N2);
      decimal AvgDensity(decimal H2, decimal CO, decimal CO2, decimal N2);
   }
}
