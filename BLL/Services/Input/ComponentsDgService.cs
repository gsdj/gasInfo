﻿using BLL.DTO.Components;
using BLL.Interfaces.Services.Input;
using DA.Entities;
using DA.Interfaces;
using System;

namespace BLL.Services.Input
{
   public class ComponentsDgService : IGasComponentsService<ComponentsDgDTO>
   {
      private IGasGenericRepository<CharacteristicsDgAll> CharacteristicsDgRep;
      public ComponentsDgService(IGasGenericRepository<CharacteristicsDgAll> rep)
      {
         CharacteristicsDgRep = rep;
      }

      public ComponentsDgDTO GetItemByDate(DateTime Date)
      {
         var dg = CharacteristicsDgRep.GetByDate(Date);
         return ToDTO(dg);
      }

      public bool InsertOrUpdate(ComponentsDgDTO entity)
      {
         CharacteristicsDgAll dg = CharacteristicsDgRep.GetByDate(entity.Date) ?? new CharacteristicsDgAll();
         try
         {
            dg.Date = entity.Date;
            dg.Kc1.CO2 = entity.Kc1.CO2;
            dg.Kc1.CO = entity.Kc1.CO;
            dg.Kc1.N2 = entity.Kc1.N2;
            dg.Kc1.H2 = entity.Kc1.H2;
            dg.Kc2.CO2 = entity.Kc2.CO2;
            dg.Kc2.CO = entity.Kc2.CO;
            dg.Kc2.N2 = entity.Kc2.N2;
            dg.Kc2.H2 = entity.Kc2.H2;

            if (dg.Id > 0)
            {
               CharacteristicsDgRep.Update(dg);
            }
            else
            {
               CharacteristicsDgRep.Create(dg);
            }
            return true;
         }
         catch (Exception ex)
         {
            return false;
         }
      }

      private ComponentsDgDTO ToDTO(CharacteristicsDgAll dg)
      {
         return new ComponentsDgDTO
         {
            Date = dg.Date,
            Kc1 =
            {
               CO2 = dg.Kc1.CO2,
               CO = dg.Kc1.CO,
               N2 = dg.Kc1.N2,
               H2 = dg.Kc1.H2,
            },
            Kc2 =
            {
               CO2 = dg.Kc2.CO2,
               CO = dg.Kc2.CO,
               N2 = dg.Kc2.N2,
               H2 = dg.Kc2.H2,
            }
         };
      }
   }
}
