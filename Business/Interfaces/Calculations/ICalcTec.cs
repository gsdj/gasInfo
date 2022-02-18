using Business.DTO;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Calculations
{
   public interface ICalcTec
   {
      IEnumerable<TecDTO> CalcEntities(IEnumerable<Tec> tec);
      TecDTO CalcEntity(Tec tec);
   }
}
