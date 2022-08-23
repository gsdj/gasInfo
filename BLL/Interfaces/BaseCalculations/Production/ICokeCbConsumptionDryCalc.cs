using BLL.Models.BaseModels.Production;
using DA.Entities;

namespace BLL.Interfaces.BaseCalculations.Production
{
   public interface ICokeCbConsumptionDryCalc : ICalculations<AmmountCb, CokeCbConsumptionDry>, ICalculation<AmmountCb, CokeCbConsumptionDry> { }
}
