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
      IEnumerable<EbChmkDTO> CalcEntities(IEnumerable<AmmountCb> cbs, IEnumerable<DgPgChmkEb> dgpgs);
      EbChmkDTO CalcEntity(IEnumerable<AmmountCb> cb, DgPgChmkEb dgpg);
   }
}
