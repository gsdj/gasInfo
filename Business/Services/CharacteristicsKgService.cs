using Business.DTO;
using Business.Interfaces.Calculations;
using Business.Interfaces.Services;
using DataAccess.Entities;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;

namespace Business.Services
{
   public class CharacteristicsKgService : ICharacteristicsService<CharacteristicsKgDTO>
   {
      IUnitOfWork db;
      ICalcCharacteristicsKg _clcKg;
      public CharacteristicsKgService(IUnitOfWork uof, ICalcCharacteristicsKg clcKg)
      {
         db = uof;
         _clcKg = clcKg;
      }

      public CharacteristicsKgDTO GetItemByDate(DateTime Date)
      {
         var charKg = db.CharacteristicsKg.GetByDate(Date);
         var result = _clcKg.CalcEntity(charKg);
         return result;
      }

      public IEnumerable<CharacteristicsKgDTO> GetItemsByMonth(DateTime Date)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<CharacteristicsKgDTO> GetItemsByNowMonth()
      {
         throw new NotImplementedException();
      }

      public void Insert(CharacteristicsKgDTO entity)
      {
         CharacteristicsKgAll kg = new CharacteristicsKgAll
         {
            Date = entity.Date,
            Kc1 =
            {

               CO = entity.Kc1.Components.CO,
               CO2 = entity.Kc1.Components.CO2,
               H2 = entity.Kc1.Components.H2,
               N2 = entity.Kc1.Components.N2,
               CH4 = entity.Kc1.Components.CH4,
               CnHm = entity.Kc1.Components.CnHm,
               O2 = entity.Kc1.Components.O2,
            },
            Kc2 =
            {
               CO = entity.Kc2.Components.CO,
               CO2 = entity.Kc2.Components.CO2,
               H2 = entity.Kc2.Components.H2,
               N2 = entity.Kc2.Components.N2,
               CH4 = entity.Kc2.Components.CH4,
               CnHm = entity.Kc2.Components.CnHm,
               O2 = entity.Kc2.Components.O2,
            }
         };
         db.CharacteristicsKg.Add(kg);
         db.Save();
      }

      public void Upsert(CharacteristicsKgDTO entity)
      {
         throw new NotImplementedException();
      }
   }
}
