using BLL.Calculations.Base;
using BLL.Interfaces.BaseCalculations;
using Xunit;

namespace Tests.Calculations.Base
{
   public class DryCokeProductionTest
   {
      private IDryCokeProduction<DefaultDryCokeProduction> GetTestObject()
      {
         return new DefaultDryCokeProduction();
      }
      [Fact]
      public void DryCokeProduction()
      {
         var target = GetTestObject();

         decimal expected = 765.4608m;
         int cb = 78;
         decimal coef = 10.44m;

         Assert.Equal(expected, target.Calc(cb, coef));
      }
   }
}
