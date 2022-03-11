using Business.BusinessModels;
using Business.BusinessModels.DataForCalculations;
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
   public class QualityService : IQualityService
   {
      IUnitOfWork db;
      IValidationDictionary _validationDictionary;
      public QualityService(IUnitOfWork uof, IValidationDictionary validation)
      {
         db = uof;
         _validationDictionary = validation;
      }

      protected bool ValidateComponents(QualityComponentsDTO dg)
      {
         return _validationDictionary.IsValid;
      }

      public QualityComponentsDTO GetItemByDate(DateTime Date)
      {
         var qual = db.Quality.GetByDate(Date);
         return new QualityComponentsDTO
         {
            Date = qual.Date,
            Kc1 =
            {
               W = qual.Kc1.W,
               A = qual.Kc1.A,
               V = qual.Kc1.V,
            },
            Kc2 =
            {
               W = qual.Kc2.W,
               A = qual.Kc2.A,
               V = qual.Kc2.V,
            }
         };
      }

      public bool Upsert(QualityComponentsDTO entity)
      {
         if (!ValidateComponents(entity))
            return false;

         try
         {
            QualityAll qual = new QualityAll
            {
               Date = entity.Date,
               Kc1 =
               {
                  W = entity.Kc1.W,
                  A = entity.Kc1.A,
                  V = entity.Kc1.V,
               },
               Kc2 =
               {
                  W = entity.Kc2.W,
                  A = entity.Kc2.A,
                  V = entity.Kc2.V,
               }
            };
            db.Quality.Create(qual);
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
