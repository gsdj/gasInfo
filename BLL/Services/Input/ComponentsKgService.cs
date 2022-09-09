using BLL.DTO.Components;
using BLL.Interfaces;
using BLL.Interfaces.Services.Input;
using DA.Entities;
using DA.Interfaces;
using System;

namespace BLL.Services.Input
{
   public class ComponentsKgService : IGasComponentsService<ComponentsKgDTO>
   {
      private IGasGenericRepository<CharacteristicsKgAll> CharacteristcsKgRep;
      public ComponentsKgService(IGasGenericRepository<CharacteristicsKgAll> rep)
      {
         CharacteristcsKgRep = rep;
      }

      public ComponentsKgDTO GetItemByDate(DateTime Date)
      {
         var kg = CharacteristcsKgRep.GetByDate(Date);
         return ToDTO(kg);
      }

      public bool InsertOrUpdate(ComponentsKgDTO entity)
      {
         CharacteristicsKgAll kg = CharacteristcsKgRep.GetByDate(entity.Date) ?? new CharacteristicsKgAll();
         try
         {
            kg.Date = entity.Date;
            kg.Kc1.CO2 = entity.Kc1.CO2;
            kg.Kc1.CO = entity.Kc1.CO;
            kg.Kc1.N2 = entity.Kc1.N2;
            kg.Kc1.H2 = entity.Kc1.H2;
            kg.Kc2.CO2 = entity.Kc2.CO2;
            kg.Kc2.CO = entity.Kc2.CO;
            kg.Kc2.N2 = entity.Kc2.N2;
            kg.Kc2.H2 = entity.Kc2.H2;

            if (kg.Id > 0)
            {
               CharacteristcsKgRep.Update(kg);
            }
            else
            {
               CharacteristcsKgRep.Create(kg);
            }
            return true;
         }
         catch (Exception ex)
         {
            return false;
         }
      }

      private ComponentsKgDTO ToDTO(CharacteristicsKgAll kg)
      {
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
   }
}
