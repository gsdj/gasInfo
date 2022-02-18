using Business.DTO;
using Business.Interfaces.Services;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;

namespace Bussiness.Services
{
   public class ProductionService : IProductionService
   {
      IUnitOfWork uof;

      public IEnumerable<ProductionDTO> GetAllByMonth(DateTime Date)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<ProductionDTO> GetAllByNowMonth()
      {
         throw new NotImplementedException();
      }

      public IEnumerable<ProductionDTO> GetAllByNowYear()
      {
         throw new NotImplementedException();
      }

      public IEnumerable<ProductionDTO> GetAllByYear(int Year)
      {
         throw new NotImplementedException();
      }

      public ProductionDTO GetByDate(DateTime Date)
      {
         throw new NotImplementedException();
      }
   }
}
