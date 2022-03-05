using Business.BusinessModels;
using Business.BusinessModels.Calculations;
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
   public class QualityService : IQualityService
   {
      IUnitOfWork db;
      ICalculations<QualityDTO> _qual;
      public QualityService(IUnitOfWork uof, ICalculations<QualityDTO> calcQ)
      {
         db = uof;
         _qual = calcQ;
      }

      public QualityDTO GetItemByDate(DateTime Date)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<QualityDTO> GetItemsByMonth(DateTime Date)
      {
         DateTime fDate = new DateTime(Date.Year, Date.Month, 1);
         DateTime lDate = new DateTime(Date.Year, Date.Month, DateTime.DaysInMonth(Date.Year, Date.Month));
         //return _qual.CalcEntities(fDate, lDate); // Method(DateTime fDate, DateTime lDate);
         throw new NotImplementedException();
      }

      public IEnumerable<QualityDTO> GetItemsByNowMonth()
      {
         DateTime date = DateTime.Now;
         DateTime fDate = new DateTime(date.Year, date.Month, 1); 
         DateTime lDate = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
         //return _qual.CalcEntities(fDate, lDate); // Method(DateTime fDate, DateTime lDate);
         throw new NotImplementedException();
      }

      //добавить один общий метод Method(DateTime fDate, DateTime lDate);

      public void Insert(QualityDTO entity)
      {
         throw new NotImplementedException();
      }

      public void Upsert(QualityDTO entity)
      {
         throw new NotImplementedException();
      }
   }
}
