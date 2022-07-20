using Business.DTO;
using DataAccess.Entities;
using System.Collections.Generic;

namespace Business.Interfaces.Calculations
{
   public interface ICalcTec
   {
      IEnumerable<TecDTO> CalcEntities(IEnumerable<Tec> tec);
      TecDTO CalcEntity(Tec tec);
   }
}
