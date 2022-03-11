using Business.DTO;
using Business.Interfaces;
using Business.Interfaces.Calculations;
using Business.Interfaces.Services;
using DataAccess.Entities;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;

namespace Business.Services.Input
{
   public class ComponentsKgService : IGasComponentsService<ComponentsKgDTO> // IComponentsService<ComponentsKg>
   {
      IUnitOfWork db;
      IValidationDictionary _validationDictionary;
      public ComponentsKgService(IUnitOfWork uof, IValidationDictionary validation)
      {
         db = uof;
         _validationDictionary = validation;
      }

      protected bool ValidateComponents(ComponentsKgDTO dg)
      {
         return _validationDictionary.IsValid;
      }

      public ComponentsKgDTO GetItemByDate(DateTime Date)
      {
         var kg = db.CharacteristicsKg.GetByDate(Date);
         return new ComponentsKgDTO
         {
            Date = kg.Date,
            Kc1 =
            {
               CO2 = kg.Kc1.CO2,
               CO = kg.Kc1.CO,
               N2 = kg.Kc1.N2,
               H2 = kg.Kc1.H2,
               O2 = kg.Kc1.O2,
               CnHm = kg.Kc1.CnHm,
               CH4 = kg.Kc1.CH4,
            },
            Kc2 =
            {
               CO2 = kg.Kc2.CO2,
               CO = kg.Kc2.CO,
               N2 = kg.Kc2.N2,
               H2 = kg.Kc2.H2,
               O2 = kg.Kc2.O2,
               CnHm = kg.Kc2.CnHm,
               CH4 = kg.Kc2.CH4,
            }
         };
      }

      public bool Upsert(ComponentsKgDTO entity)
      {
         if (!ValidateComponents(entity))
            return false;

         try
         {
            CharacteristicsKgAll kg = new CharacteristicsKgAll
            {
               Date = entity.Date,
               Kc1 =
               {
                  CO2 = entity.Kc1.CO2,
                  CO = entity.Kc1.CO,
                  N2 = entity.Kc1.N2,
                  H2 = entity.Kc1.H2,
                  O2 = entity.Kc1.O2,
                  CnHm = entity.Kc1.CnHm,
                  CH4 = entity.Kc1.CH4,
               },
               Kc2 =
               {
                  CO2 = entity.Kc2.CO2,
                  CO = entity.Kc2.CO,
                  N2 = entity.Kc2.N2,
                  H2 = entity.Kc2.H2,
                  O2 = entity.Kc2.O2,
                  CnHm = entity.Kc2.CnHm,
                  CH4 = entity.Kc2.CH4,
               }
            };
            db.CharacteristicsKg.Create(kg);
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
