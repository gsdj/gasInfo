using Business.Interfaces.Calculations;
using Business.DTO;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessModels.Calculations
{
   public class CalcProduction : ICalcProduction
   {
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

            Cb16Dry = Math.Round(CbDry(cbs.Cb1, cbs.OutputMultipliers.Cb1) + CbDry(cbs.Cb2, cbs.OutputMultipliers.Cb2) +
                                 CbDry(cbs.Cb3, cbs.OutputMultipliers.Cb3) + CbDry(cbs.Cb4, cbs.OutputMultipliers.Cb4) +
                                 CbDry(cbs.Cb5, cbs.OutputMultipliers.Cb5) + CbDry(cbs.Cb6, cbs.OutputMultipliers.Cb6), 4),

            Cb78Dry = Math.Round(CbDry(cbs.Cb7, cbs.OutputMultipliers.Cb7) + CbDry(cbs.Cb8, cbs.OutputMultipliers.Cb8), 4),
            KpeDry = Math.Round(cbs.PKP * cbs.OutputMultipliers.PKP, 4),
            Cb16ConsDry = Math.Round(((CbDry(cbs.Cb1, cbs.OutputMultipliers.Cb1) + CbDry(cbs.Cb2, cbs.OutputMultipliers.Cb2) + 
                                       CbDry(cbs.Cb3, cbs.OutputMultipliers.Cb3) + CbDry(cbs.Cb4, cbs.OutputMultipliers.Cb4) + 
                                       CbDry(cbs.Cb5, cbs.OutputMultipliers.Cb5) + CbDry(cbs.Cb6, cbs.OutputMultipliers.Cb6)) * cbs.OutputMultipliers.Sv), 4),

            Cb78ConsDry = Math.Round((CbDry(cbs.Cb7, cbs.OutputMultipliers.Cb7) + CbDry(cbs.Cb8, cbs.OutputMultipliers.Cb8)) * cbs.OutputMultipliers.Sv, 4),
            ConsumptionFvKc1 = 
            {
               Cb1 = ConsFv(cbs.Cb1, cbs.OutputMultipliers.Cb1, cbs.OutputMultipliers.Fv),
               Cb2 = ConsFv(cbs.Cb2, cbs.OutputMultipliers.Cb2, cbs.OutputMultipliers.Fv),
               Cb3 = ConsFv(cbs.Cb3, cbs.OutputMultipliers.Cb3, cbs.OutputMultipliers.Fv),
               Cb4 = ConsFv(cbs.Cb4, cbs.OutputMultipliers.Cb4, cbs.OutputMultipliers.Fv),
            },
            ConsumptionFvKc2 =
            {
               Cb5 = ConsFv(cbs.Cb5, cbs.OutputMultipliers.Cb5, cbs.OutputMultipliers.Fv),
               Cb6 = ConsFv(cbs.Cb6, cbs.OutputMultipliers.Cb6, cbs.OutputMultipliers.Fv),
               Cb7 = ConsFv(cbs.Cb7, cbs.OutputMultipliers.Cb7, cbs.OutputMultipliers.Fv),
               Cb8 = ConsFv(cbs.Cb8, cbs.OutputMultipliers.Cb8, cbs.OutputMultipliers.Fv),
            },
            PkoKpe = (cbs.OutputMultipliers.Peka == 0) ? 0 : Math.Round(cbs.OutputMultipliers.Peka / 100, 4),
            SpoPerKus = (cbs.OutputMultipliers.Peka == 0) ? 0 : Math.Round(((cbs.PKP * cbs.OutputMultipliers.PKP) * Constants.SpoC) / (cbs.OutputMultipliers.Peka / 100), 4),
            SvC = cbs.OutputMultipliers.Sv,
            FvC = cbs.OutputMultipliers.Fv,
            KpeC = cbs.OutputMultipliers.Peka,
         };
      }
      /// <summary>
      /// Производство кокса сух.
      /// </summary>
      public decimal CbDry(int Cb, decimal CbCoef)
      {
         return Cb * CbCoef * Constants.Kb18C;
      }
      /// <summary>
      /// Расход шихты в Ф.В.
      /// </summary>
      public decimal ConsFv(int Cb, decimal CbCoef, decimal FvCoef)
      {
         return Math.Round(CbDry(Cb, CbCoef) * FvCoef, 4);
      }
   }
}
