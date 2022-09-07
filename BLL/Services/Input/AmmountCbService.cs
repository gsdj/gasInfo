using BLL.DTO.Input;
using BLL.Interfaces.Service.Input;
using DA.Entities;
using DA.Interfaces;
using System;

namespace BLL.Services.Input
{
   public class AmmountCbService : IAmmountCbService
   {
      private IUnitOfWork Db;
      public AmmountCbService(IUnitOfWork db)
      {
         Db = db;
      }
      public AmmountCbDTO GetItemByDate(DateTime Date)
      {
         return ToDTO(Db.AmmountCb.GetByDate(Date));
      }
      public bool InsertOrUpsert(AmmountCbDTO entity)
      {
         DateTime dtom = new DateTime(entity.Date.Year, entity.Date.Month, entity.Date.Day);
         OutputMultipliers om = Db.Multipliers.GetByDate(dtom);

         AmmountCb cb = new AmmountCb
         {
            Date = entity.Date,
            Cb1 = entity.Cb1,
            Cb2 = entity.Cb2,
            Cb3 = entity.Cb3,
            Cb4 = entity.Cb4,
            Cb5 = entity.Cb5,
            Cb6 = entity.Cb6,
            Cb7 = entity.Cb7,
            Cb8 = entity.Cb8,
            PKP = entity.PKP,
            OutputMultipliers = om,
         };
         try
         {
            if (Db.AmmountCb.GetByDate(entity.Date) != null)
            {
               Db.AmmountCb.Update(cb);
            }
            else
            {
               Db.AmmountCb.Create(cb);
            }
            return true;
         }
         catch (Exception ex)
         {
            return false;
         }

      }
      private AmmountCbDTO ToDTO(AmmountCb cb)
      {
         return new AmmountCbDTO
         {
            Date = cb.Date,
            Cb1 = cb.Cb1,
            Cb2 = cb.Cb1,
            Cb3 = cb.Cb1,
            Cb4 = cb.Cb1,
            Cb5 = cb.Cb1,
            Cb6 = cb.Cb1,
            Cb7 = cb.Cb1,
            Cb8 = cb.Cb1,
            PKP = cb.PKP,
         };
      }
   }
}
