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
   public class CalcDgPgChmkEb : ICalcDgPgChmkEb
   {
      public IEnumerable<DgPgChmkEbDTO> CalcEntities(IEnumerable<DgPgChmkEb> dgpg)
      {
         List<DgPgChmkEbDTO> DgPgDTOList = new List<DgPgChmkEbDTO>(dgpg.Count());
         foreach (var item in dgpg)
         {
            DgPgDTOList.Add(CalcEntity(item));
         }
         return DgPgDTOList;
      }

      public DgPgChmkEbDTO CalcEntity(DgPgChmkEb dgpg)
      {
         return new DgPgChmkEbDTO
         {
            Date = dgpg.Date,
            ConsumptionDgKc1 =
            {
               Cb1 = dgpg.ConsDgCb1,
               Cb2 = dgpg.ConsDgCb2,
               Cb3 = dgpg.ConsDgCb3,
               Cb4 = dgpg.ConsDgCb4,
            },
            ConsDgKc1Sum = dgpg.ConsDgCb1 + dgpg.ConsDgCb2 + dgpg.ConsDgCb3 + dgpg.ConsDgCb4,
            ConsumptionPgGru =
            {
               Gru1 = dgpg.ConsPgGru1,
               Gru2 = dgpg.ConsPgGru2,
            },
            ConsPgUpc = dgpg.ConsPgGru1 + dgpg.ConsPgGru2,
         };
      }
   }
}
