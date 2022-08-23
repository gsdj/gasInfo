using BLL.DTO.Input;
using DA.Entities;
using System.Collections.Generic;

namespace BLL.Interfaces.Calculations
{
   public interface ICalcTec
   {
      IEnumerable<TecDTO> CalcEntities(IEnumerable<Tec> tec);
      TecDTO CalcEntity(Tec tec);
   }
}
