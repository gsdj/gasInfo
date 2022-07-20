using Business.DTO.Models.General;
using DataAccess.Entities;

namespace Business.Interfaces.BaseCalculations.Production
{
   public interface ICokeCbConsumptionFvCalc : ICalculations<AmmountCb, CbAll>, ICalculation<AmmountCb, CbAll> { }
}
