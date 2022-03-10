using Business.DTO;
using Business.Interfaces.Calculations;
using Business.Interfaces.Services;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;

namespace Bussiness.Services.Reporting
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
         return CalcProduction.CalcEntities(db.AmmountCb.GetPerMonth(Date.Year, Date.Month));
      }

      public IEnumerable<ProductionDTO> GetItemsByNowMonth()
      {
         DateTime dateNow = DateTime.Now;
         return CalcProduction.CalcEntities(db.AmmountCb.GetPerMonth(dateNow.Year, dateNow.Month));
      }
   }
}
