using Business.BusinessModels;
using Business.BusinessModels.DataForCalculations;
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
   public class QualityService2 : IQualityService
   {
      IUnitOfWork db;
      ICalculations<QualityDTO> _qual;
      ICalcCharacteristicsKg CalcKg;
      public QualityDTO GetItemByDate(DateTime Date)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<QualityDTO> GetItemsByMonth(DateTime Date)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<QualityDTO> GetItemsByNowMonth()
      {
         DateTime date = DateTime.Now;
         DateTime fDate = new DateTime(date.Year, date.Month, 1);
         DateTime lDate = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));

         var Qualities = db.Quality.Get(p => p.Date >= fDate && p.Date <= lDate);
         var KgDTOs = CalcKg.CalcEntities(db.CharacteristicsKg.Get(p => p.Date >= fDate && p.Date <= lDate));

         var QData =
            from t1q in db.Quality.Get(p => p.Date >= fDate && p.Date <= lDate)
            join t2charKg in KgDTOs on new { t1q.Date } equals new { t2charKg.Date }
            select new QualityData
            {
               Qualities = t1q,
               Kg = t2charKg,
            };

         List<QualityDTO> qDTOs = new List<QualityDTO>(QData.Count());

         foreach (var item in QData)
         {
            qDTOs.Add(_qual.CalcEntity(item));
         }

         return qDTOs;
      }

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
