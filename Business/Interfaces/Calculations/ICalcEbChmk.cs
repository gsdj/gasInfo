using Business.DTO;
using DataAccess.Entities;
using System.Collections.Generic;

namespace Business.Interfaces.Calculations
{
   public interface ICalcEbChmk
   {
      IEnumerable<EbChmkDTO> CalcEntities(IEnumerable<AmmountCb> cbs, IEnumerable<DgPgChmkEb> dgpgs);
      EbChmkDTO CalcEntity(IEnumerable<AmmountCb> cb, DgPgChmkEb dgpg);
   }
}
