using BLL.Interfaces.BaseCalculations;
using BLL.Models.BaseModels.Production;
using DA.Entities;

namespace BLL.Interfaces.Calculations.Production
{
   public interface ICokeCbDryCalc : ICalculations<AmmountCb, CokeCbDry>, ICalculation<AmmountCb, CokeCbDry> { }
}
