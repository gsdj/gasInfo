using Business.DTO.Models.Production;
using DataAccess.Entities;

namespace Business.Interfaces.BaseCalculations.Production
{
   public interface ICokeCbConsumptionDryCalc : ICalculations<AmmountCb, CokeCbConsumptionDry>, ICalculation<AmmountCb, CokeCbConsumptionDry> { }
}
