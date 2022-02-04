using Bussiness.DTO;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Calculations
{
   public interface ICalcProduction
   {
      IEnumerable<ProductionDTO> CalcEntities(IEnumerable<AmmountCb> cbs);
      ProductionDTO CalcEntity(AmmountCb cbs);
      decimal CbDry(int Cb, decimal CbCoef);
      decimal ConsFv(int Cb, decimal CbCoef, decimal FvCoef);
   }
}
