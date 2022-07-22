using Business.BusinessModels.BaseCalculations;
using Business.BusinessModels.BaseCalculations.Production;
using Business.DTO.Models.Production;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.BaseCalculations.Production;
using Newtonsoft.Json;
using Xunit;

namespace Tests.Calculations.Entities.Production
{
   public class CokeCbConsumptionDryTest
   {
      private IDryCokeProduction<DefaultDryCokeProduction> DryCoke;
      private ICokeCbConsumptionDryCalc TestedObject;
      public CokeCbConsumptionDryTest()
      {
         DryCoke = new DefaultDryCokeProduction();
         TestedObject = new CokeCbConsumptionDryCalc(DryCoke);
      }
      private CokeCbConsumptionDry ExpectedObject()
      {
         return new CokeCbConsumptionDry
         {
            Kc1 =
            {
               Cb1 = 975.1970592m,
               Cb2 = 1285.6046112m,
               Cb3 = 0.00000m,
               Cb4 = 1227.2594880m,
            },
            Kc2 =
            {
               Cb1 = 766.2467904m,
               Cb2 = 766.2467904m,
               Cb3 = 750.2833156m,
               Cb4 = 842.8906304m,
            },
         };
      }

      [Fact]
      public void CokeConsumptionDry()
      {
         var expected = JsonConvert.SerializeObject(ExpectedObject());
         var result = JsonConvert.SerializeObject(TestedObject.CalcEntity(TestDataHelper.AmmountCbData()));

         Assert.Equal(expected, result);
      }
   }
}
