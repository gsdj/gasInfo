using BLL.DTO.Input;
using BLL.Interfaces.Service.Input;
using DA.Entities;
using DA.Interfaces;
using System;

namespace BLL.Services.Input
{
   public class MultipliersService : IMultipliersService
   {
      private IGasGenericRepository<OutputMultipliers> MultipliersRep;
      public MultipliersService(IGasGenericRepository<OutputMultipliers> rep)
      {
         MultipliersRep = rep;
      }
      public OutputMultipliersDTO GetItemByDate(DateTime Date)
      {
         return ToDTO(MultipliersRep.GetByDate(Date));
      }
      public bool InsertOrUpdate(OutputMultipliersDTO entity)
      {
         DateTime dt = new DateTime(entity.Date.Year, entity.Date.Month, 1);
         DateTime dtNextMonth = dt.AddMonths(1);

         OutputMultipliers om = MultipliersRep.GetByDate(dt) ?? new OutputMultipliers();
         OutputMultipliers omNextMonth = MultipliersRep.GetByDate(dtNextMonth) ?? new OutputMultipliers();

         try
         {
            InsUpd(om, entity, dt);
            InsUpd(omNextMonth, entity, dtNextMonth);
            return true;
         }
         catch (Exception ex)
         {
            return false;
         }
      }

      private void InsUpd(OutputMultipliers dbEntity, OutputMultipliersDTO entity, DateTime date)
      {
         dbEntity.Date = date;
         dbEntity.Cb1 = entity.Cb1;
         dbEntity.Cb2 = entity.Cb1;
         dbEntity.Cb3 = entity.Cb1;
         dbEntity.Cb4 = entity.Cb1;
         dbEntity.Cb5 = entity.Cb1;
         dbEntity.Cb6 = entity.Cb1;
         dbEntity.Cb7 = entity.Cb1;
         dbEntity.Cb8 = entity.Cb1;
         dbEntity.PKP = entity.PKP;
         dbEntity.Sv = entity.Sv;
         dbEntity.Fv = entity.Fv;
         dbEntity.Peka = entity.Peka;

         if (dbEntity.Id > 0)
         {
            MultipliersRep.Update(dbEntity);

         }
         else
         {
            MultipliersRep.Create(dbEntity);
         }
      }
      private OutputMultipliersDTO ToDTO(OutputMultipliers om)
      {
         return new OutputMultipliersDTO
         {
            Date = om.Date,
            Cb1 = om.Cb1,
            Cb2 = om.Cb1,
            Cb3 = om.Cb1,
            Cb4 = om.Cb1,
            Cb5 = om.Cb1,
            Cb6 = om.Cb1,
            Cb7 = om.Cb1,
            Cb8 = om.Cb1,
            PKP = om.PKP,
            Sv = om.Sv,
            Fv = om.Fv,
            Peka = om.Peka,
         };
      }
   }
}
