using BLL.Calculations.Base;
using BLL.DTO;
using BLL.Interfaces.BaseCalculations;
using BLL.Interfaces.Calculations;
using BLL.Interfaces.Calculations.Production;
using DA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Calculations.Entities
{
   public class DefaultProduction : ICalcProduction
   {
      private ISpoPerKus<DefaultSpoPerKus> SpoPerKus;
      private ICokeCbGrossCalc CokeCbGrossCalc;
      private ICokeCbDryCalc CokeCbDryCalc;
      private ICokeCbConsumptionDryCalc CokeCbConsumptionDryCalc;
      private ICokeCbConsumptionFvCalc CokeCbConsumptionFvCalc;
      public DefaultProduction(ISpoPerKus<DefaultSpoPerKus> perKus, ICokeCbGrossCalc gross, ICokeCbDryCalc dry, ICokeCbConsumptionDryCalc consdry, ICokeCbConsumptionFvCalc consfv)
      {
         SpoPerKus = perKus;
         CokeCbGrossCalc = gross;
         CokeCbDryCalc = dry;
         CokeCbConsumptionDryCalc = consdry;
         CokeCbConsumptionFvCalc = consfv;
      }
      public IEnumerable<ProductionDTO> CalcEntities(IEnumerable<AmmountCb> cbs)
      {
         List<ProductionDTO> prod = new List<ProductionDTO>(cbs.Count());
         foreach (var item in cbs)
         {
            prod.Add(CalcEntity(item));
         }
         return prod;
      }
      public ProductionDTO CalcEntity(AmmountCb cbs)
      {
         if (cbs == null)
            throw new NullReferenceException();

         return new ProductionDTO
         {
            Date = cbs.Date,
            AmmountCb =
               {
                  Cb1 = cbs.Cb1,
                  Cb2 = cbs.Cb2,
                  Cb3 = cbs.Cb3,
                  Cb4 = cbs.Cb4,
                  Cb5 = cbs.Cb5,
                  Cb6 = cbs.Cb6,
                  Cb7 = cbs.Cb7,
                  Cb8 = cbs.Cb8,
                  PKP = cbs.PKP,
               },
            CokeCbGross = CokeCbGrossCalc.CalcEntity(cbs),
            CokeCbDry = CokeCbDryCalc.CalcEntity(cbs),
            CokeCbConsumptionDry = CokeCbConsumptionDryCalc.CalcEntity(cbs),
            CokeCbConsumptionFv = CokeCbConsumptionFvCalc.CalcEntity(cbs),
            PkoKpe = (cbs.OutputMultipliers.Peka == 0) ? 0 : Math.Round(cbs.OutputMultipliers.Peka / 100, 4),
            SpoPerKus = (cbs.OutputMultipliers.Peka == 0) ? 0 : SpoPerKus.Calc(cbs.PKP, cbs.OutputMultipliers.PKP, cbs.OutputMultipliers.Peka),
         };
      }
   }
}
