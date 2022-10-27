using BLL.DTO;
using BLL.Interfaces.Calculations.Production;
using BLL.Interfaces.Services.Report;
using DA.Entities;
using DA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services.Reporting
{
   public class ProductionService : IProductionService
   {
      IUnitOfWork db;
      //ICalcProduction CalcProduction;
      ICokeCbGrossCalc CokeCbGrossCalc;
      ICokeCbDryCalc CokeCbDryCalc;
      ICokeCbConsumptionDryCalc CokeCbConsumptionDryCalc;
      ICokeCbConsumptionFvCalc CokeCbConsumptionFvCalc;
      public ProductionService(IUnitOfWork uof, /*ICalcProduction calcProd*/ICokeCbGrossCalc gross, ICokeCbDryCalc dry, ICokeCbConsumptionDryCalc consdry, ICokeCbConsumptionFvCalc consfv)
      {
         db = uof;
         CokeCbGrossCalc = gross;
         CokeCbDryCalc = dry;
         CokeCbConsumptionDryCalc = consdry;
         CokeCbConsumptionFvCalc = consfv;
         //CalcProduction = calcProd;
      }
      public IEnumerable<ProductionDTO> GetItemsByMonth(DateTime Date)
      {
         return BuildProduction(db.AmmountCb.GetPerMonth(Date.Year, Date.Month).ToList());
         //return CalcProduction.CalcEntities(db.AmmountCb.GetPerMonth(Date.Year, Date.Month));
      }

      public IEnumerable<ProductionDTO> GetItemsByNowMonth()
      {
         DateTime dateNow = DateTime.Now;
         return BuildProduction(db.AmmountCb.GetPerMonth(dateNow.Year, dateNow.Month).ToList());
         //return CalcProduction.CalcEntities(db.AmmountCb.GetPerMonth(dateNow.Year, dateNow.Month));
      }

      private IEnumerable<ProductionDTO> BuildProduction(IEnumerable<AmmountCb> data)
      {
         List<ProductionDTO> prod = new List<ProductionDTO>(data.Count());
         foreach (var item in data)
         {
            prod.Add(new ProductionDTO
            {
               Date = item.Date,
               AmmountCb =
               {
                  Cb1 = item.Cb1,
                  Cb2 = item.Cb2,
                  Cb3 = item.Cb3,
                  Cb4 = item.Cb4,
                  Cb5 = item.Cb5,
                  Cb6 = item.Cb6,
                  Cb7 = item.Cb7,
                  Cb8 = item.Cb8,
                  PKP = item.PKP,
               },
               CokeCbGross = CokeCbGrossCalc.CalcEntity(item),
               CokeCbDry = CokeCbDryCalc.CalcEntity(item),
               CokeCbConsumptionDry = CokeCbConsumptionDryCalc.CalcEntity(item),
               CokeCbConsumptionFv = CokeCbConsumptionFvCalc.CalcEntity(item),
            });
         }
         return prod;
      }
   }
}
