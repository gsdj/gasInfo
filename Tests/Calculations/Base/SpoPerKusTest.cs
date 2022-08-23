using BLL.Calculations.Base;
using BLL.Interfaces.BaseCalculations;
using Xunit;

namespace Tests.Calculations.Base
{
   public class SpoPerKusTest
   {
      private ISpoPerKus<DefaultSpoPerKus> GetTestObject()
      {
         return new DefaultSpoPerKus();
      }
      [Fact]
      public void SpoPerKus()
      {
         var target = GetTestObject();

         decimal pkp = 12;
         decimal pkpCoef = 6.94m;
         decimal pekaCoef = 420;
         decimal expected = 24.3494857143m;

         Assert.Equal(expected, target.Calc(pkp, pkpCoef, pekaCoef));
      }
   }
}
