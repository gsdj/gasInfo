using BLL.Interfaces.Calculations.Production;
using BLL.Models.BaseModels.Production;
using DA.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Calculations.Entities.Production
{
   public class CokeCbGrossCalc : ICokeCbGrossCalc
   {
      public IEnumerable<CokeCbGross> CalcEntities(IEnumerable<AmmountCb> data)
      {
         List<CokeCbGross> cokeCbGross = new List<CokeCbGross>(data.Count());
         foreach (var item in data)
         {
            cokeCbGross.Add(CalcEntity(item));
         }
         return cokeCbGross;
      }

      public CokeCbGross CalcEntity(AmmountCb data)
      {
         return new CokeCbGross
         {
            Kc1 =
            {
               Cb1 = data.Cb1 * data.OutputMultipliers.Cb1,
               Cb2 = data.Cb2 * data.OutputMultipliers.Cb2,
               Cb3 = data.Cb3 * data.OutputMultipliers.Cb3,
               Cb4 = data.Cb4 * data.OutputMultipliers.Cb4,
            },
            Kc2 =
            {
               Cb1 = data.Cb5 * data.OutputMultipliers.Cb5,
               Cb2 = data.Cb6 * data.OutputMultipliers.Cb6,
               Cb3 = data.Cb7 * data.OutputMultipliers.Cb7,
               Cb4 = data.Cb8 * data.OutputMultipliers.Cb8,
            }
         };
      }
   }
}
