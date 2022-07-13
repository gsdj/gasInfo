using Business.DTO.General;
using Business.DTO.Models.Production;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.BaseCalculations.Production
{
   public interface ICokeCbConsumptionFvCalc : ICalculations<AmmountCb, CbAll>, ICalculation<AmmountCb, CbAll> { }
}
