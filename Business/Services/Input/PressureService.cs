using Business.DTO;
using Business.Interfaces.Calculations;
using Business.Interfaces.Services;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Input
{
   public class PressureService : IPressureService
   {
      IUnitOfWork db;
      public PressureService(IUnitOfWork uof)
      {
         db = uof;
      }

      public PressureDTO GetItemByDate(DateTime Date)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<PressureDTO> GetItemsByMonth(DateTime Date)
      {
         return GetItemsByDate(Date);
      }

      public IEnumerable<PressureDTO> GetItemsByNowMonth()
      {
         DateTime dateNow = DateTime.Now;
         return GetItemsByDate(dateNow);
      }

      private IEnumerable<PressureDTO> GetItemsByDate(DateTime Date)
      {
         return db.Pressure.GetPerMonth(Date.Year, Date.Month).Select(p => new PressureDTO
         {
            Date = p.Date,
            Value = p.Value,
            ValuePa = p.Value * 133.3224m,
         });
      }

      public void Insert(PressureDTO entity)
      {
         throw new NotImplementedException();
      }

      public void Upsert(PressureDTO entity)
      {
         throw new NotImplementedException();
      }
   }
}
