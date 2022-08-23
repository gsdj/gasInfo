using BLL.Calculations.Base.Production;
using BLL.Interfaces.BaseCalculations.Production;
using BLL.Models.BaseModels.Production;
using Newtonsoft.Json;
using Xunit;

namespace Tests.Calculations.Entities.Production
{
   public class CokeCbGrossTest
   {
      private ICokeCbGrossCalc TestedObject;
      public CokeCbGrossTest()
      {
         TestedObject = new CokeCbGrossCalc();
      }
      private CokeCbGross ExpectedObject()
      {
         return new CokeCbGross
         {
            Kc1 =
            {
               Cb1 = 814.32m,
               Cb2 = 1073.52m,
               Cb3 = 0,
               Cb4 = 1024.80m,
            },
            Kc2 =
            {
               Cb1 = 639.84m,
               Cb2 = 639.84m,
               Cb3 = 626.51m,
               Cb4 = 703.84m,
            },
         };
      }

      [Fact]
      public void CokeGross()
      {
         var expected = JsonConvert.SerializeObject(ExpectedObject());
         var result = JsonConvert.SerializeObject(TestedObject.CalcEntity(TestDbDataHelper.AmmountCbData()));

         Assert.Equal(expected, result);
      }
   }
}
