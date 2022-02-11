using Business.DTO;
using Business.Interfaces.Calculations;
using Business.Interfaces.Services;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
   public class CharacteristicsDgService : ICharacteristicsService<CharacteristicsDgDTO>
   {
      IUnitOfWork db;
      ICalcCharacteristicsDg _clcDg;
      public CharacteristicsDgService(IUnitOfWork uof, ICalcCharacteristicsDg clcDg)
      {
         db = uof;
         _clcDg = clcDg;
      }

      public IEnumerable<CharacteristicsDgDTO> GetAllByMonth(DateTime Date)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<CharacteristicsDgDTO> GetAllByNowMonth()
      {
         throw new NotImplementedException();
      }

      public IEnumerable<CharacteristicsDgDTO> GetAllByNowYear()
      {
         throw new NotImplementedException();
      }

      public IEnumerable<CharacteristicsDgDTO> GetAllByYear(int Year)
      {
         throw new NotImplementedException();
      }

      public CharacteristicsDgDTO GetByDate(DateTime Date)
      {
         throw new NotImplementedException();
      }

      public void Insert(CharacteristicsDgDTO entity)
      {
         throw new NotImplementedException();
      }

      public void Upsert(CharacteristicsDgDTO entity)
      {
         throw new NotImplementedException();
      }
   }
}
