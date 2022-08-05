using Business.BusinessModels.BaseCalculations;
using Business.BusinessModels.BaseCalculations.Production;
using Business.DTO.Models.Production;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.BaseCalculations.Production;
using Newtonsoft.Json;
using Xunit;

namespace Tests.Calculations.Entities.Production
{
   public class CokeCbDryTest
   {
      private IDryCokeProduction<DefaultDryCokeProduction> DryCoke;
      private ICokeCbDryCalc TestedObject;
      public CokeCbDryTest()
      {
         DryCoke = new DefaultDryCokeProduction();
         TestedObject = new CokeCbDryCalc(DryCoke);
      }
      private CokeCbDry ExpectedObject()
      {
         return new CokeCbDry
         {
            Kc1 =
            {
               Cb1 = 765.4608m,
               Cb2 = 1009.1088m,
               Cb3 = 0.00m,
               Cb4 = 963.3120m,
            },
            Kc2 =
            {
               Cb1 = 601.4496m,
               Cb2 = 601.4496m,
               Cb3 = 588.9194m,
               Cb4 = 661.6096m,
            },
            KpeDry = 83.28m,
         };
      }

      [Fact]
      public void CokeDry()
      {
         var expected = JsonConvert.SerializeObject(ExpectedObject());
         var result = JsonConvert.SerializeObject(TestedObject.CalcEntity(TestDbDataHelper.AmmountCbData()));

         Assert.Equal(expected, result);
      }
   }
}
