using BLL.Models.BaseModels.Production;
using DA.Entities;

namespace BLL.Interfaces.BaseCalculations.Production
{
   public interface ICokeCbGrossCalc : ICalculations<AmmountCb, CokeCbGross>, ICalculation<AmmountCb,CokeCbGross> { }
}
