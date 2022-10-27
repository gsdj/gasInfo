using BLL.Interfaces.BaseCalculations;
using BLL.Models.BaseModels.Production;
using DA.Entities;

namespace BLL.Interfaces.Calculations.Production
{
   public interface ICokeCbGrossCalc : ICalculations<AmmountCb, CokeCbGross>, ICalculation<AmmountCb,CokeCbGross> { }
}
