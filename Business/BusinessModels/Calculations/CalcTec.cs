using Business.DTO;
using Business.Interfaces.Calculations;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessModels.Calculations
{
   public class CalcTec : ICalcTec
   {
      public IEnumerable<TecDTO> CalcEntities(IEnumerable<Tec> tec)
      {
         List<TecDTO> tecDTO = new List<TecDTO>(tec.Count());
         foreach (var item in tec)
         {
            tecDTO.Add(CalcEntity(item));
         }
         return tecDTO;
      }

      public TecDTO CalcEntity(Tec tec)
      {
         return new TecDTO
         {
            Date = tec.Date,
            Chmk = tec.Chmk,
            TecNorth = tec.TecNorth,
            TecSouth = tec.TecSouth,
            TecSum = tec.TecNorth + tec.TecSouth,
            ChmkTecSum = tec.TecSouth + tec.TecNorth + tec.Chmk,
            ChmkTecPerHour = (tec.TecSouth + tec.TecNorth + tec.Chmk) / 24,
         };
      }
   }
}
