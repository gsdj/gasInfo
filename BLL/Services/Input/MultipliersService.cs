using BLL.DTO.Input;
using BLL.Interfaces.Service.Input;
using DA.Entities;
using DA.Interfaces;
using System;

namespace BLL.Services.Input
{
   public class MultipliersService : IMultipliersService
   {
      private IUnitOfWork Db;
      public MultipliersService(IUnitOfWork db)
      {
         Db = db;
      }
      public OutputMultipliersDTO GetItemByDate(DateTime Date)
      {
         return ToDTO(Db.Multipliers.GetByDate(Date));
      }
      public bool InsertOrUpdate(OutputMultipliersDTO entity)
      {
         //подумать чё сделать
         DateTime dt = new DateTime(entity.Date.Year, entity.Date.Month, 1);
         OutputMultipliers om = Db.Multipliers.GetByDate(dt) ?? new OutputMultipliers();
         try
         {
            om.Date = entity.Date;
            om.Cb1 = entity.Cb1;
            om.Cb2 = entity.Cb1;
            om.Cb3 = entity.Cb1;
            om.Cb4 = entity.Cb1;
            om.Cb5 = entity.Cb1;
            om.Cb6 = entity.Cb1;
            om.Cb7 = entity.Cb1;
            om.Cb8 = entity.Cb1;
            om.PKP = entity.PKP;
            om.Sv = entity.Sv;
            om.Fv = entity.Fv;
            om.Peka = entity.Peka;

            if (om.Id > 0)
            {
               Db.Multipliers.Update(om);
               
            }
            else
            {
               Db.Multipliers.Create(om);
            }
            return true;
         }
         catch (Exception ex)
         {
            return false;
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
