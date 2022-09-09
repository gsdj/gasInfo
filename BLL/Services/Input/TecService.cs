using BLL.DTO.Input;
using BLL.Interfaces.Service.Input;
using DA.Entities;
using DA.Interfaces;
using System;

namespace BLL.Services.Input
{
   public class TecService : ITecService
   {
      private IGasGenericRepository<Tec> TecRep;
      public TecService(IGasGenericRepository<Tec> rep)
      {
         TecRep = rep;
      }
      public TecDTO GetItemByDate(DateTime Date)
      {
         return ToDTO(TecRep.GetByDate(Date));
      }
      public bool InsertOrUpdate(TecDTO entity)
      {
         Tec t = TecRep.GetByDate(entity.Date) ?? new Tec();
         try
         {
            t.Date = entity.Date;
            t.Chmk = entity.Chmk;
            t.TecNorth = entity.TecNorth;
            t.TecSouth = entity.TecSouth;

            if (t.Id > 0)
            {
               TecRep.Update(t);
            }
            else
            {
               TecRep.Create(t);
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
