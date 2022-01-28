using Bussiness.DTO;
using Bussiness.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.BusinessModels
{
   public class CalculationProduction : IEntitiesCalculations<ProductionDTO>
   {
      private ProductionDTO _prod;
      public CalculationProduction(ProductionDTO prod) // при инициализации передавать необходимые сущности
      {
         _prod = prod;
      }

      public ProductionDTO Calc()
      {
         throw new NotImplementedException();
      }
   }
}
