using Business.BusinessModels.DataForCalculations;
using Business.Interfaces;
using Business.Interfaces.BaseCalculations.Density;
using Moq;
using Xunit;

namespace Tests.Calculations.Entities
{
   public class OutputKgTest
   {
      private Mock<ISteamCharacteristicsService> MockSteam;
      private Mock<IDryDensity> MockDryDensity;
      private Mock<IWetDensity> MockWetDensity;
      private Data Data;
      public OutputKgTest()
      {
         MockSteam = new Mock<ISteamCharacteristicsService>();
         MockSteam.Setup(p => p.GetCharacteristics()).Returns(TestDataHelper.SteamCharacteristicsData());

         MockDryDensity = new Mock<IDryDensity>();
         MockWetDensity = new Mock<IWetDensity>();

         Data = new Data
         {
            CharacteristicsDg = TestDataHelper.CharacteristicsDgData(),
            CharacteristicsKg = TestDataHelper.CharacteristicsKgData(),
            Kip = TestDataHelper.DevicesKipData(),
            Pressure = TestDataHelper.PressureData(),
         };
      }
      [Fact]
      public void OutputKg()
      {

      }
   }
}
