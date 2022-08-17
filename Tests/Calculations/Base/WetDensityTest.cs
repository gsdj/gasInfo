using Business.BusinessModels.BaseCalculations.Density;
using Business.Interfaces.BaseCalculations.Density;
using Business.Interfaces.Services;
using Moq;
using Xunit;

namespace Tests.Calculations.Base
{
   public class WetDensityTest
   {
      [Fact]
      public void WetDensity()
      {
         var mock = new Mock<ISteamCharacteristicsService>();

         var mockResult = TestCalculatedDataHelper.SteamCharacteristicsData();

         mock.Setup(p => p.GetCharacteristics()).Returns(mockResult);

         IWetDensity target = new WetDensity(mock.Object);

         decimal dryGas = 0.409731518254958m;
         decimal temp = 31;

         decimal expected = 0.4418315183m;
         Assert.Equal(expected, target.Calc(dryGas,temp));
      }
   }
}
