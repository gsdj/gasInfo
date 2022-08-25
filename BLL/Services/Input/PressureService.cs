﻿using BLL.DTO.Input;
using BLL.Interfaces;
using BLL.Interfaces.Services.Input;
using DA.Entities;
using DA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services.Input
{
   public class PressureService : IPressureService
   {
      //duplicate validation
      /// <summary>
      /// проверить есть ли такая запись : есть - обновить, нет - вставить
      /// </summary>
      
      //model validation 
      /// <summary>
      /// отдельный валидор проверки правильности введных полей, для того чтобы не дублировать логику в presentation layer`s
      /// return dictionary<key,value> ?
      /// в presentation layer modelstate.adderror ?
      /// </summary>
      /// 
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

      public bool InsertOrUpsert(PressureDTO entity)
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
