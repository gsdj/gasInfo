using Business.DTO.Models.Production;
using DataAccess.Entities;

namespace Business.Interfaces.BaseCalculations.Production
{
   public interface ICokeCbDryCalc : ICalculations<AmmountCb, CokeCbDry>, ICalculation<AmmountCb, CokeCbDry> { }
}
