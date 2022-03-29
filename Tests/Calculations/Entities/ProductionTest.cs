using Business.BusinessModels.BaseCalculations;
using Business.BusinessModels.Calculations;
using Business.DTO;
using Business.DTO.Consumption;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.Calculations;
using DataAccess.Entities;
using Newtonsoft.Json;
using System;
using Xunit;

namespace Tests.Calculations.Entities
{
   public class ProductionTest
   {
      private ICalcProduction GetTestObject()
      {
         IDryCokeProduction<DefaultDryCokeProduction> dryCoke = new DefaultDryCokeProduction();
         IChargeConsFV<DefaultChargeConsFV> consFv = new DefaultChargeConsFV(new DefaultDryCokeProduction());
         ISpoPerKus<DefaultSpoPerKus> perKus = new DefaultSpoPerKus();
         return new CalcProduction(dryCoke, consFv, perKus);
      }
      [Fact]
      public void Production()
      {
         var target = GetTestObject();

         ProductionDTO expectedResult = new ProductionDTO
         {
            Date = new DateTime(2019, 1, 1),
            AmmountCb = new AmmountCb<int>
            {
               Cb1 = 78,
               Cb2 = 84,
               Cb3 = 0,
               Cb4 = 80,
               Cb5 = 48,
               Cb6 = 48,
               Cb7 = 47,
               Cb8 = 53,
               PKP = 12,
            },
            Cb16Val = 4192.32m,
            Cb78Val = 1330.35m,
            Cb16Dry = 3940.7808m,
            Cb78Dry = 1250.5290m,
            TnDry = 5191.3098m,
            KpeDry = 83.28m,
            Cb16ConsDry = 5020.5547m,
            Cb78ConsDry = 1593.1739m,
            TnConsDry = 6613.7287m,
            ConsumptionFvKc1 = new ConsumptionKc1<decimal>
            {
               Cb1 = 1052.5086m,
               Cb2 = 1387.5246m,
               Cb3 = 0.0000m,
               Cb4 = 1324.5540m,
            },
            ConsumptionFvKc2 = new ConsumptionKc2<decimal>
            {
               Cb5 = 826.9932m,
               Cb6 = 826.9932m,
               Cb7 = 809.7642m,
               Cb8 = 909.7132m,
            },
            PkoKpe = 4.2m,
            SpoPerKus = 24.3495m,
            SvC = 1.274m,
            FvC = 1.375m,
            KpeC = 420,
         };

         var expected = JsonConvert.SerializeObject(expectedResult);
         var result = JsonConvert.SerializeObject(target.CalcEntity(TestHelper.AmmountCbData()));

         Assert.Equal(expected, result);
      }
   }
}
