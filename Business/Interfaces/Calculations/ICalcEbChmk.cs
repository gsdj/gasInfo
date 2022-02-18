using Business.DTO;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Calculations
{
   public interface ICalcEbChmk
   {
      IEnumerable<EbChmkDTO> CalcEntities(IEnumerable<ProductionDTO> prod, IEnumerable<DgPgChmkEbDTO> dgpgChmkEbs);
      EbChmkDTO CalcEntity(IEnumerable<ProductionDTO> prod, DgPgChmkEbDTO eb);
   }
}
