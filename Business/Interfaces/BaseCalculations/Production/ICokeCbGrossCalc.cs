using Business.DTO.Models.Production;
using DataAccess.Entities;

namespace Business.Interfaces.BaseCalculations.Production
{
   public interface ICokeCbGrossCalc : ICalculations<AmmountCb, CokeCbGross>, ICalculation<AmmountCb,CokeCbGross> { }
}
