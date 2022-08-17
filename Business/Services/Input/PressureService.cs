using Business.DTO;
using Business.Interfaces;
using Business.Interfaces.Services.Input;
using DataAccess.Entities;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services.Input
{
   public class PressureService : IPressureService
   {
      IUnitOfWork db;
      IValidationDictionary _validationDictionary;
      IValidator<PressureDTO> Validator;
      public PressureService(IUnitOfWork uof, IValidationDictionary validation, IValidator<PressureDTO> validator)
      {
         db = uof;
         _validationDictionary = validation;
         Validator = validator;
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
         return db.Pressure.GetPerMonth(Date.Year, Date.Month).Select(p => ToDTO(p));
      }

      public IEnumerable<PressureDTO> GetItemsByNowMonth()
      {
         DateTime dateNow = DateTime.Now;
         return db.Pressure.GetPerMonth(dateNow.Year, dateNow.Month).Select(p => ToDTO(p));
      }

      public bool Upsert(PressureDTO entity)
      {
         if (!ValidateComponents(entity))
            return false;

         if (!Validator.Validate(entity))
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

      public IEnumerable<PressureDTO> GetItemsByYear(int Year)
      {
         return db.Pressure.GetPerYear(Year).Select(p => ToDTO(p));
      }

      public IEnumerable<PressureDTO> GetItemsByNowYear()
      {
         int Year = DateTime.Now.Year;
         return db.Pressure.GetPerYear(Year).Select(p => ToDTO(p));
      }

      private PressureDTO ToDTO(Pressure pressure)
      {
         return new PressureDTO
         {
            Date = pressure.Date,
            Value = pressure.Value,
            ValuePa = pressure.Value * 133.3224m,
         };
      }
   }
}
