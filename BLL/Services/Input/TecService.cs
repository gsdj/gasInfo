using BLL.DTO.Input;
using BLL.Interfaces.Service.Input;
using DA.Entities;
using DA.Interfaces;
using System;

namespace BLL.Services.Input
{
   public class TecService : ITecService
   {
      private IUnitOfWork Db;
      public TecService(IUnitOfWork db)
      {
         Db = db;
      }
      public TecDTO GetItemByDate(DateTime Date)
      {
         return ToDTO(Db.Tec.GetByDate(Date));
      }
      public bool InsertOrUpdate(TecDTO entity)
      {
         Tec t = Db.Tec.GetByDate(entity.Date) ?? new Tec();
         try
         {
            t.Date = entity.Date;
            t.Chmk = entity.Chmk;
            t.TecNorth = entity.TecNorth;
            t.TecSouth = entity.TecSouth;

            if (t.Id > 0)
            {
               Db.Tec.Update(t);
            }
            else
            {
               Db.Tec.Create(t);
            }
            return true;
         }
         catch (Exception ex)
         {
            return false;
         }
      }
      private TecDTO ToDTO(Tec t)
      {
         return new TecDTO
         {
            Date = t.Date,
            Chmk = t.Chmk,
            TecNorth = t.TecNorth,
            TecSouth = t.TecNorth,
         };
      }
   }
}
