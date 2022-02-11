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

      public IEnumerable<CharacteristicsKgDTO> GetAllByMonth(DateTime Date)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<CharacteristicsKgDTO> GetAllByNowMonth()
      {
         var charKg = db.CharacteristicsKg.GetPerMonth();
         var result = _clcKg.CalcEntities(charKg);
         return result;
      }

      public IEnumerable<CharacteristicsKgDTO> GetAllByNowYear()
      {
         throw new NotImplementedException();
      }

      public IEnumerable<CharacteristicsKgDTO> GetAllByYear(int Year)
      {
         throw new NotImplementedException();
      }

      public CharacteristicsKgDTO GetByDate(DateTime Date)
      {
         var charKg = db.CharacteristicsKg.GetByDate(Date);
         var result = _clcKg.CalcEntity(charKg);
         return result;
      }

      public void Insert(CharacteristicsKgDTO entity)
      {
         CharacteristicsKgAll kg = new CharacteristicsKgAll
         {
            Date = entity.Date,
            Kc1 =
            {

               CO = entity.Kc1.CO,
               CO2 = entity.Kc1.CO2,
               H2 = entity.Kc1.H2,
               N2 = entity.Kc1.N2,
               CH4 = entity.Kc1.CH4,
               CnHm = entity.Kc1.CnHm,
               O2 = entity.Kc1.O2,
            },
            Kc2 =
            {
               CO = entity.Kc2.CO,
               CO2 = entity.Kc2.CO2,
               H2 = entity.Kc2.H2,
               N2 = entity.Kc2.N2,
               CH4 = entity.Kc2.CH4,
               CnHm = entity.Kc2.CnHm,
               O2 = entity.Kc2.O2,
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
