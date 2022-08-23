using BLL.Models.BaseModels.General;
using DA.Entities;

namespace BLL.Interfaces.BaseCalculations.Production
{
   public interface ICokeCbConsumptionFvCalc : ICalculations<AmmountCb, CbAll>, ICalculation<AmmountCb, CbAll> { }
}
