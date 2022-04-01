using Business.BusinessModels.BaseCalculations;
using Business.Interfaces.BaseCalculations;
using Moq;
using Xunit;

namespace Tests.Calculations.Base
{
   public class ChargeConsFVTest
   {
      [Fact]
      public void ChargeConsFv()
      {
         var mock = new Mock<IDryCokeProduction<DefaultDryCokeProduction>>();

         int cb = 78;
         decimal coef = 10.44m;
         decimal FvCoef = 1.274m;

         decimal mockResult = 765.4608m;
         mock.Setup(p => p.Calc(It.IsAny<int>(), It.IsAny<decimal>())).Returns(mockResult);

         IChargeConsFV<DefaultChargeConsFV> target = new DefaultChargeConsFV(mock.Object);

         decimal expected = 975.1970592m;

         Assert.Equal(expected, target.Calc(cb, coef, FvCoef));

      }
   }
}
