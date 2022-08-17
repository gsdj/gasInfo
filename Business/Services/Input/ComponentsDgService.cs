using Business.DTO.Components;
using Business.Interfaces;
using Business.Interfaces.Services.Input;
using DataAccess.Entities;
using DataAccess.Interfaces;
using System;

namespace Business.Services.Input
{
   public class ComponentsDgService : IGasComponentsService<ComponentsDgDTO>
   {
      IUnitOfWork db;
      IValidationDictionary _validationDictionary;
      public ComponentsDgService(IUnitOfWork uof, IValidationDictionary validation)
      {
         _validationDictionary = validation;
         db = uof;
      }

      protected bool ValidateComponents(ComponentsDgDTO dg)
      {
         return _validationDictionary.IsValid;
      }

      public ComponentsDgDTO GetItemByDate(DateTime Date)
      {
         var dg = db.CharacteristicsDg.GetByDate(Date);
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

      public bool Upsert(ComponentsDgDTO entity)
      {
         if (!ValidateComponents(entity))
            return false;

         try
         {
            CharacteristicsDgAll dg = new CharacteristicsDgAll
            {
               Date = entity.Date,
               Kc1 =
               {
                  CO2 = entity.Kc1.CO2,
                  CO = entity.Kc1.CO,
                  N2 = entity.Kc1.N2,
                  H2 = entity.Kc1.H2,
               },
               Kc2 =
               {
                  CO2 = entity.Kc2.CO2,
                  CO = entity.Kc2.CO,
                  N2 = entity.Kc2.N2,
                  H2 = entity.Kc2.H2,
               }
            };
            db.CharacteristicsDg.Create(dg);
            db.Save();
         }
         catch (Exception)
         {
            return false;
         }
         return true;
      }
   }
}
