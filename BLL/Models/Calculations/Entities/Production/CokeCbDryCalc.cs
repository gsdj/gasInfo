using BLL.Calculations.Base;
using BLL.Interfaces.BaseCalculations;
using BLL.Interfaces.Calculations.Production;
using BLL.Models.BaseModels.Production;
using DA.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Calculations.Entities.Production
{
   public class CokeCbDryCalc : ICokeCbDryCalc
   {
      private IDryCokeProduction<DefaultDryCokeProduction> DryCoke;
      public CokeCbDryCalc(IDryCokeProduction<DefaultDryCokeProduction> dryCoke)
      {
         DryCoke = dryCoke;
      }
      public IEnumerable<CokeCbDry> CalcEntities(IEnumerable<AmmountCb> data)
      {
         List<CokeCbDry> cokeCbGross = new List<CokeCbDry>(data.Count());
         foreach (var item in data)
         {
            cokeCbGross.Add(CalcEntity(item));
         }
         return cokeCbGross;
      }

      public CokeCbDry CalcEntity(AmmountCb data)
      {
         return new CokeCbDry
         {
            Kc1 =
            {
               Cb1 = DryCoke.Calc(data.Cb1, data.OutputMultipliers.Cb1),
               Cb2 = DryCoke.Calc(data.Cb2, data.OutputMultipliers.Cb2),
               Cb3 = DryCoke.Calc(data.Cb3, data.OutputMultipliers.Cb3),
               Cb4 = DryCoke.Calc(data.Cb4, data.OutputMultipliers.Cb4),
            },
            Kc2 =
            {
               Cb1 = DryCoke.Calc(data.Cb5, data.OutputMultipliers.Cb5),
               Cb2 = DryCoke.Calc(data.Cb6, data.OutputMultipliers.Cb6),
               Cb3 = DryCoke.Calc(data.Cb7, data.OutputMultipliers.Cb7),
               Cb4 = DryCoke.Calc(data.Cb8, data.OutputMultipliers.Cb8),
            },
            KpeDry = data.PKP * data.OutputMultipliers.PKP,
         };
      }
   }
}
