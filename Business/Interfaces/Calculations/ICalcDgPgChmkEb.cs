using Business.DTO;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Calculations
{
   public interface ICalcDgPgChmkEb
   {
      IEnumerable<DgPgChmkEbDTO> CalcEntities(IEnumerable<DgPgChmkEb> dgpg);
      DgPgChmkEbDTO CalcEntity(DgPgChmkEb dgpg);
   }
}
