using Business.DTO;
using Business.Interfaces.Services;
using Bussiness.Interfaces.Services;
using DataAccess.Interfaces;

namespace Bussiness.Services
{
   public class ProductionService : IProductionService
   {
      IUnitOfWork uof;
      ICharacteristicsService<CharacteristicsKgDTO> kgser;
      public void Test()
      {
         var res = kgser.GetAllByNowMonth();
      }
   }
}
