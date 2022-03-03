using Business.DTO;
using Business.Interfaces;
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
      IValidationDictionary _validationDictionary;
      public CharacteristicsDgService(IUnitOfWork uof, ICalcCharacteristicsDg clcDg, IValidationDictionary validation)
      {
         _validationDictionary = validation;
         db = uof;
         _clcDg = clcDg;
      }

      public CharacteristicsDgDTO GetItemByDate(DateTime Date)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<CharacteristicsDgDTO> GetItemsByMonth(DateTime Date)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<CharacteristicsDgDTO> GetItemsByNowMonth()
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
