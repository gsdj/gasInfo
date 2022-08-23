using BLL.Models.BaseModels.Production;
using DA.Entities;

namespace BLL.Interfaces.BaseCalculations.Production
{
   public interface ICokeCbDryCalc : ICalculations<AmmountCb, CokeCbDry>, ICalculation<AmmountCb, CokeCbDry> { }
}
