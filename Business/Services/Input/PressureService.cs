using Business.DTO;
using Business.Interfaces;
using Business.Interfaces.Calculations;
using Business.Interfaces.Services;
using DataAccess.Entities;
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
      IValidationDictionary _validationDictionary;
      public PressureService(IUnitOfWork uof, IValidationDictionary validation)
      {
         db = uof;
         _validationDictionary = validation;
      }

      protected bool ValidateComponents(PressureDTO dg)
      {
         return _validationDictionary.IsValid;
      }

      public PressureDTO GetItemByDate(DateTime Date)
      {
         var pressure = db.Pressure.GetByDate(Date);
         return new PressureDTO
         {
            Date = pressure.Date,
            Value = pressure.Value,
         };
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

      public bool Upsert(PressureDTO entity)
      {
         if (!ValidateComponents(entity))
            return false;

         try
         {
            Pressure pressure = new Pressure
            {
               Date = entity.Date,
               Value = entity.Value,
            };
            db.Pressure.Create(pressure);
            db.Save();
         }
         catch (Exception)
         {
            return false;
         }
         return true;
      }
   }
}
