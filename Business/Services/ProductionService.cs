using Bussiness.BusinessModels;
using Bussiness.DTO;
using Bussiness.Interfaces;
using DataAccess;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services
{
   public class ProductionService : IProductionService
   {
      IEntitiesCalculations<ProductionDTO> calc;
      IUnitOfWork uof;
      public void Test()
      {
         var a = uof.DevicesKip.GetByDate(DateTime.Now);
         var sad = a.Cb1.SteamCharacteristics.Fkg;
         var prod = new ProductionDTO();
         calc = new CalculationProduction(prod);
         var res = calc.Calc();
      }
   }
}
