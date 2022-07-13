using Business.BusinessModels.BaseCalculations.Consumption;
using Business.DTO.General;
using Business.DTO.Models.Production;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.BaseCalculations.Consumption;
using Business.Interfaces.BaseCalculations.Production;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessModels.BaseCalculations.Production
{
   public class CokeCbConsumptionFvCalc : ICokeCbConsumptionFvCalc
   {
      private IChargeConsFV<DefaultChargeConsFV> ChargeConsFV;
      public CokeCbConsumptionFvCalc(IChargeConsFV<DefaultChargeConsFV> consFv)
      {
         ChargeConsFV = consFv;
      }
      public IEnumerable<CbAll> CalcEntities(IEnumerable<AmmountCb> data)
      {
         List<CbAll> cokeCbGross = new List<CbAll>(data.Count());
         foreach (var item in data)
         {
            cokeCbGross.Add(CalcEntity(item));
         }
         return cokeCbGross;
      }

      public CbAll CalcEntity(AmmountCb data)
      {
         return new CbAll
         {
            Kc1 =
            {
               Cb1 = ChargeConsFV.Calc(data.Cb1, data.OutputMultipliers.Cb1, data.OutputMultipliers.Fv),
               Cb2 = ChargeConsFV.Calc(data.Cb2, data.OutputMultipliers.Cb2, data.OutputMultipliers.Fv),
               Cb3 = ChargeConsFV.Calc(data.Cb3, data.OutputMultipliers.Cb3, data.OutputMultipliers.Fv),
               Cb4 = ChargeConsFV.Calc(data.Cb4, data.OutputMultipliers.Cb4, data.OutputMultipliers.Fv),
            },
            Kc2 =
            {
               Cb1 = ChargeConsFV.Calc(data.Cb5, data.OutputMultipliers.Cb5, data.OutputMultipliers.Fv),
               Cb2 = ChargeConsFV.Calc(data.Cb6, data.OutputMultipliers.Cb6, data.OutputMultipliers.Fv),
               Cb3 = ChargeConsFV.Calc(data.Cb7, data.OutputMultipliers.Cb7, data.OutputMultipliers.Fv),
               Cb4 = ChargeConsFV.Calc(data.Cb8, data.OutputMultipliers.Cb8, data.OutputMultipliers.Fv),
            }
         };
      }
   }
}
