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
      public IEnumerable<PressureDTO> GetAllByMonth(DateTime Date)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<PressureDTO> GetAllByNowMonth()
      {
         return db.Pressure.GetPerMonth().Select(p => new PressureDTO 
         {
            Date = p.Date,
            Value = p.Value,
         });
      }

      public IEnumerable<PressureDTO> GetAllByNowYear()
      {
         throw new NotImplementedException();
      }

      public IEnumerable<PressureDTO> GetAllByYear(int Year)
      {
         throw new NotImplementedException();
      }

      public PressureDTO GetByDate(DateTime Date)
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
