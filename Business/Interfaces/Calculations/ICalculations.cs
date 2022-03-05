using Business.BusinessModels;
using Business.BusinessModels.DataForCalculations;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Calculations
{
   public interface ICalculations<T>
   {
      T CalcEntity(Data data);
   }
}
