using BLL.DTO.Input;
using BLL.Interfaces.Service.Input;
using BLL.Models.BaseModels.General;
using DA.Entities;
using DA.Interfaces;
using System;

namespace BLL.Services.Input.ChmkEb
{
   public class DgPgChmkEbService : IDgPgChmkEb
   {
      private IGasGenericRepository<DgPgChmkEb> Rep;
      public DgPgChmkEbService(IGasGenericRepository<DgPgChmkEb> rep)
      {
         Rep = rep;
      }
      public DgPgChmkEbDTO GetItemByDate(DateTime Date)
      {
         var dg = ToDTO(Rep.GetByDate(Date));
         return dg;         
      }

      public bool InsertOrUpdate(DgPgChmkEbDTO entity)
      {
         DgPgChmkEb dgpg = Rep.GetByDate(entity.Date) ?? new DgPgChmkEb();
         try
         {
            dgpg.Date = entity.Date;
            dgpg.ConsDgCb1 = (int)entity.ConsumptionDgKc1.Cb1;
            dgpg.ConsDgCb2 = (int)entity.ConsumptionDgKc1.Cb2;
            dgpg.ConsDgCb3 = (int)entity.ConsumptionDgKc1.Cb3;
            dgpg.ConsDgCb4 = (int)entity.ConsumptionDgKc1.Cb4;
            dgpg.ConsPgGru1 = (int)entity.ConsumptionPgGru.Gru1;
            dgpg.ConsPgGru2 = (int)entity.ConsumptionPgGru.Gru2;

            if (dgpg.Id > 0)
            {
               Rep.Update(dgpg);
            }
            else
            {
               Rep.Create(dgpg);
            }
            return true;
         }
         catch (Exception ex)
         {
            return false;
         }
      }

      private DgPgChmkEbDTO ToDTO(DgPgChmkEb dgpgeb)
      {
         return new DgPgChmkEbDTO
         {
            Date = dgpgeb.Date,
            ConsumptionDgKc1 = new CbKc
            {
               Cb1 = dgpgeb.ConsDgCb1,
               Cb2 = dgpgeb.ConsDgCb2,
               Cb3 = dgpgeb.ConsDgCb3,
               Cb4 = dgpgeb.ConsDgCb4,
            },
            ConsumptionPgGru = new Gru
            {
               Gru1 = dgpgeb.ConsPgGru1,
               Gru2 = dgpgeb.ConsPgGru2,
            },
         };
      }
   }
}
