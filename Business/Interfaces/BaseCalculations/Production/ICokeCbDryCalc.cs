using Business.DTO.Models.Production;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.BaseCalculations.Production
{
   public interface ICokeCbDryCalc : ICalculations<AmmountCb, CokeCbDry>, ICalculation<AmmountCb, CokeCbDry> { }
}
