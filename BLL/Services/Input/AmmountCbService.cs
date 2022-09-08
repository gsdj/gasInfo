﻿using BLL.DTO.Input;
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
      public bool InsertOrUpdate(AmmountCbDTO entity)
      {
         AmmountCb cb = Db.AmmountCb.GetByDate(entity.Date) ?? new AmmountCb();
         try
         {
            cb.Date = entity.Date;
            cb.Cb1 = entity.Cb1;
            cb.Cb2 = entity.Cb2;
            cb.Cb3 = entity.Cb3;
            cb.Cb4 = entity.Cb4;
            cb.Cb5 = entity.Cb5;
            cb.Cb6 = entity.Cb6;
            cb.Cb7 = entity.Cb7;
            cb.Cb8 = entity.Cb8;
            cb.PKP = entity.PKP;

            if (cb.Id > 0)
            {
               Db.AmmountCb.Update(cb);
            }
            else
            {
               DateTime dtom = new DateTime(entity.Date.Year, entity.Date.Month, 1);
               OutputMultipliers om = Db.Multipliers.GetByDate(dtom);

               cb.OutputMultipliers = om;

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
