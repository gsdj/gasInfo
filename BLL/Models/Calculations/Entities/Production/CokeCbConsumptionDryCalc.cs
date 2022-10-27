using BLL.Calculations.Base;
using BLL.Interfaces.BaseCalculations;
using BLL.Interfaces.Calculations.Production;
using BLL.Models.BaseModels.Production;
using DA.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Calculations.Entities.Production
{
   public class CokeCbConsumptionDryCalc : ICokeCbConsumptionDryCalc
   {
      private IDryCokeProduction<DefaultDryCokeProduction> DryCoke;
      public CokeCbConsumptionDryCalc(IDryCokeProduction<DefaultDryCokeProduction> dryCoke)
      {
         DryCoke = dryCoke;
      }
      public IEnumerable<CokeCbConsumptionDry> CalcEntities(IEnumerable<AmmountCb> data)
      {
         List<CokeCbConsumptionDry> cokeCbGross = new List<CokeCbConsumptionDry>(data.Count());
         foreach (var item in data)
         {
            cokeCbGross.Add(CalcEntity(item));
         }
         return cokeCbGross;
      }

      public CokeCbConsumptionDry CalcEntity(AmmountCb data)
      {
         return new CokeCbConsumptionDry
         {
            Kc1 =
            {
               Cb1 = DryCoke.Calc(data.Cb1, data.OutputMultipliers.Cb1) * data.OutputMultipliers.Sv,
               Cb2 = DryCoke.Calc(data.Cb2, data.OutputMultipliers.Cb2) * data.OutputMultipliers.Sv,
               Cb3 = DryCoke.Calc(data.Cb3, data.OutputMultipliers.Cb3) * data.OutputMultipliers.Sv,
               Cb4 = DryCoke.Calc(data.Cb4, data.OutputMultipliers.Cb4) * data.OutputMultipliers.Sv,
            },
            Kc2 =
            {
               Cb1 = DryCoke.Calc(data.Cb5, data.OutputMultipliers.Cb5) * data.OutputMultipliers.Sv,
               Cb2 = DryCoke.Calc(data.Cb6, data.OutputMultipliers.Cb6) * data.OutputMultipliers.Sv,
               Cb3 = DryCoke.Calc(data.Cb7, data.OutputMultipliers.Cb7) * data.OutputMultipliers.Sv,
               Cb4 = DryCoke.Calc(data.Cb8, data.OutputMultipliers.Cb8) * data.OutputMultipliers.Sv,
            },
         };
      }
   }
}
