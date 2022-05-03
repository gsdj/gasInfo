using Business.Interfaces.Calculations;
using Business.DTO;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Business.Interfaces.BaseCalculations;
using Business.BusinessModels.BaseCalculations;
using Business.Interfaces.BaseCalculations.Consumption;
using Business.BusinessModels.BaseCalculations.Consumption;

namespace Business.BusinessModels.Calculations
{
   public class CalcProduction : ICalcProduction
   {
      private IDryCokeProduction<DefaultDryCokeProduction> DryCoke;
      private IChargeConsFV<DefaultChargeConsFV> ChargeConsFV;
      private ISpoPerKus<DefaultSpoPerKus> SpoPerKus;
      public CalcProduction(IDryCokeProduction<DefaultDryCokeProduction> dryCoke, IChargeConsFV<DefaultChargeConsFV> consFv, ISpoPerKus<DefaultSpoPerKus> perKus)
      {
         DryCoke = dryCoke;
         ChargeConsFV = consFv;
         SpoPerKus = perKus;
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
            Cb16Val = Math.Round(((cbs.Cb1 * cbs.OutputMultipliers.Cb1) + (cbs.Cb2 * cbs.OutputMultipliers.Cb2) + 
                                    (cbs.Cb3 * cbs.OutputMultipliers.Cb3) + (cbs.Cb4 * cbs.OutputMultipliers.Cb4) +
                                    (cbs.Cb5 * cbs.OutputMultipliers.Cb5) + (cbs.Cb6 * cbs.OutputMultipliers.Cb6)), 4),

            Cb78Val = Math.Round(((cbs.Cb7 * cbs.OutputMultipliers.Cb7) + (cbs.Cb8 * cbs.OutputMultipliers.Cb8)), 4),

            Cb16Dry = Math.Round(DryCoke.Calc(cbs.Cb1, cbs.OutputMultipliers.Cb1) + DryCoke.Calc(cbs.Cb2, cbs.OutputMultipliers.Cb2) +
                                 DryCoke.Calc(cbs.Cb3, cbs.OutputMultipliers.Cb3) + DryCoke.Calc(cbs.Cb4, cbs.OutputMultipliers.Cb4) +
                                 DryCoke.Calc(cbs.Cb5, cbs.OutputMultipliers.Cb5) + DryCoke.Calc(cbs.Cb6, cbs.OutputMultipliers.Cb6), 4),

            Cb78Dry = Math.Round(DryCoke.Calc(cbs.Cb7, cbs.OutputMultipliers.Cb7) + DryCoke.Calc(cbs.Cb8, cbs.OutputMultipliers.Cb8), 4),
            TnDry = Math.Round(DryCoke.Calc(cbs.Cb1, cbs.OutputMultipliers.Cb1) + DryCoke.Calc(cbs.Cb2, cbs.OutputMultipliers.Cb2) +
                                 DryCoke.Calc(cbs.Cb3, cbs.OutputMultipliers.Cb3) + DryCoke.Calc(cbs.Cb4, cbs.OutputMultipliers.Cb4) +
                                 DryCoke.Calc(cbs.Cb5, cbs.OutputMultipliers.Cb5) + DryCoke.Calc(cbs.Cb6, cbs.OutputMultipliers.Cb6) +
                                 DryCoke.Calc(cbs.Cb7, cbs.OutputMultipliers.Cb7) + DryCoke.Calc(cbs.Cb8, cbs.OutputMultipliers.Cb8), 4),
            KpeDry = Math.Round(cbs.PKP * cbs.OutputMultipliers.PKP, 4),
            Cb16ConsDry = Math.Round(((DryCoke.Calc(cbs.Cb1, cbs.OutputMultipliers.Cb1) + DryCoke.Calc(cbs.Cb2, cbs.OutputMultipliers.Cb2) + 
                                       DryCoke.Calc(cbs.Cb3, cbs.OutputMultipliers.Cb3) + DryCoke.Calc(cbs.Cb4, cbs.OutputMultipliers.Cb4) + 
                                       DryCoke.Calc(cbs.Cb5, cbs.OutputMultipliers.Cb5) + DryCoke.Calc(cbs.Cb6, cbs.OutputMultipliers.Cb6)) * cbs.OutputMultipliers.Sv), 4),

            Cb78ConsDry = Math.Round((DryCoke.Calc(cbs.Cb7, cbs.OutputMultipliers.Cb7) + DryCoke.Calc(cbs.Cb8, cbs.OutputMultipliers.Cb8)) * cbs.OutputMultipliers.Sv, 4),
            TnConsDry = Math.Round(((DryCoke.Calc(cbs.Cb1, cbs.OutputMultipliers.Cb1) + DryCoke.Calc(cbs.Cb2, cbs.OutputMultipliers.Cb2) +
                                       DryCoke.Calc(cbs.Cb3, cbs.OutputMultipliers.Cb3) + DryCoke.Calc(cbs.Cb4, cbs.OutputMultipliers.Cb4) +
                                       DryCoke.Calc(cbs.Cb5, cbs.OutputMultipliers.Cb5) + DryCoke.Calc(cbs.Cb6, cbs.OutputMultipliers.Cb6) +
                                       DryCoke.Calc(cbs.Cb7, cbs.OutputMultipliers.Cb7) + DryCoke.Calc(cbs.Cb8, cbs.OutputMultipliers.Cb8)) * cbs.OutputMultipliers.Sv), 4),
            ConsumptionFv =
            {
               Kc1 =
               {
                  Cb1 = ChargeConsFV.Calc(cbs.Cb1, cbs.OutputMultipliers.Cb1, cbs.OutputMultipliers.Fv),
                  Cb2 = ChargeConsFV.Calc(cbs.Cb2, cbs.OutputMultipliers.Cb2, cbs.OutputMultipliers.Fv),
                  Cb3 = ChargeConsFV.Calc(cbs.Cb3, cbs.OutputMultipliers.Cb3, cbs.OutputMultipliers.Fv),
                  Cb4 = ChargeConsFV.Calc(cbs.Cb4, cbs.OutputMultipliers.Cb4, cbs.OutputMultipliers.Fv),
               },
               Kc2 =
               {
                  Cb1 = ChargeConsFV.Calc(cbs.Cb5, cbs.OutputMultipliers.Cb5, cbs.OutputMultipliers.Fv),
                  Cb2 = ChargeConsFV.Calc(cbs.Cb6, cbs.OutputMultipliers.Cb6, cbs.OutputMultipliers.Fv),
                  Cb3 = ChargeConsFV.Calc(cbs.Cb7, cbs.OutputMultipliers.Cb7, cbs.OutputMultipliers.Fv),
                  Cb4 = ChargeConsFV.Calc(cbs.Cb8, cbs.OutputMultipliers.Cb8, cbs.OutputMultipliers.Fv),
               }
            },

            PkoKpe = (cbs.OutputMultipliers.Peka == 0) ? 0 : Math.Round(cbs.OutputMultipliers.Peka / 100, 4),
            SpoPerKus = (cbs.OutputMultipliers.Peka == 0) ? 0 : SpoPerKus.Calc(cbs.PKP, cbs.OutputMultipliers.PKP, cbs.OutputMultipliers.Peka),
            SvC = cbs.OutputMultipliers.Sv,
            FvC = cbs.OutputMultipliers.Fv,
            KpeC = cbs.OutputMultipliers.Peka,
         };
      }
   }
}
