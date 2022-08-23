using BLL.DTO;
using DA.Entities;
using System.Collections.Generic;

namespace BLL.Interfaces.Calculations
{
   public interface ICalcEbChmk
   {
      IEnumerable<EbChmkDTO> CalcEntities(IEnumerable<AmmountCb> cbs, IEnumerable<DgPgChmkEb> dgpgs);
      EbChmkDTO CalcEntity(IEnumerable<AmmountCb> cb, DgPgChmkEb dgpg);
   }
}
