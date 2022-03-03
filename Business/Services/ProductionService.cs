using Business.DTO;
using Business.Interfaces.Calculations;
using Business.Interfaces.Services;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;

namespace Bussiness.Services
{
   public class ProductionService : IProductionService
   {
      IUnitOfWork db;
      ICalcProduction CalcProduction;
      public ProductionService(IUnitOfWork uof, ICalcProduction calcProd)
      {
         db = uof;
         CalcProduction = calcProd;
      }
      public IEnumerable<ProductionDTO> GetItemsByMonth(DateTime Date)
      {
         var ammountCb = db.AmmountCb.GetPerMonth(Date.Year, Date.Month);
         var result = CalcProduction.CalcEntities(ammountCb);
         return result;
      }

      public IEnumerable<ProductionDTO> GetItemsByNowMonth()
      {
         DateTime dateNow = DateTime.Now;
         var ammountCb = db.AmmountCb.GetPerMonth(dateNow.Year, dateNow.Month);
         var result = CalcProduction.CalcEntities(ammountCb);
         return result;
      }
   }
}
