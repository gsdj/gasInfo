using Business.DTO;
using DataAccess.Entities;
using System.Collections.Generic;

namespace Business.Interfaces.Calculations
{
   public interface ICalcDgPgChmkEb
   {
      IEnumerable<DgPgChmkEbDTO> CalcEntities(IEnumerable<DgPgChmkEb> dgpg);
      DgPgChmkEbDTO CalcEntity(DgPgChmkEb dgpg);
   }
}
