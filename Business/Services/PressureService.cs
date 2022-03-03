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
         return db.Pressure.GetPerMonth(Date.Year, Date.Month).Select(p => new PressureDTO
         {
            Date = p.Date,
            Value = p.Value,
         });
      }

      public IEnumerable<PressureDTO> GetItemsByNowMonth()
      {
         throw new NotImplementedException();
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
