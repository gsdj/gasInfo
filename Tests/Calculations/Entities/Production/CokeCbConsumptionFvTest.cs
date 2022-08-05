using Business.BusinessModels.BaseCalculations;
using Business.BusinessModels.BaseCalculations.Consumption;
using Business.BusinessModels.BaseCalculations.Production;
using Business.DTO.Models.General;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.BaseCalculations.Consumption;
using Business.Interfaces.BaseCalculations.Production;
using Newtonsoft.Json;
using Xunit;

namespace Tests.Calculations.Entities.Production
{
   public class CokeCbConsumptionFvTest
   {
      private IChargeConsFV<DefaultChargeConsFV> ChargeConsFV;
      private IDryCokeProduction<DefaultDryCokeProduction> DryCoke;
      private ICokeCbConsumptionFvCalc TestedObject;
      public CokeCbConsumptionFvTest()
      {
         DryCoke = new DefaultDryCokeProduction();
         ChargeConsFV = new DefaultChargeConsFV(DryCoke);
         TestedObject = new CokeCbConsumptionFvCalc(ChargeConsFV);
      }
      private CbAll ExpectedObject()
      {
         return new CbAll
         {
            Kc1 =
            {
               Cb1 = 1052.5086000m,
               Cb2 = 1387.5246000m,
               Cb3 = 0.00000m,
               Cb4 = 1324.5540000m,
            },
            Kc2 =
            {
               Cb1 = 826.9932000m,
               Cb2 = 826.9932000m,
               Cb3 = 809.7641750m,
               Cb4 = 909.7132000m,
            },
         };
      }

      [Fact]
      public void CokeConsumptionFv()
      {
         var expected = JsonConvert.SerializeObject(ExpectedObject());
         var result = JsonConvert.SerializeObject(TestedObject.CalcEntity(TestDbDataHelper.AmmountCbData()));

         Assert.Equal(expected, result);
      }
   }
}
