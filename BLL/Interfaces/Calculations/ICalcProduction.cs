using BLL.DTO;
using DA.Entities;
using System.Collections.Generic;

namespace BLL.Interfaces.Calculations
{
   public interface ICalcProduction
   {
      IEnumerable<ProductionDTO> CalcEntities(IEnumerable<AmmountCb> cbs);
      ProductionDTO CalcEntity(AmmountCb cbs);
      //decimal CbDry(int Cb, decimal CbCoef);
      //decimal ConsFv(int Cb, decimal CbCoef, decimal FvCoef);
   }
}
