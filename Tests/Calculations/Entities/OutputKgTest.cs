using Business.BusinessModels.DataForCalculations;
using Business.Interfaces;
using Business.Interfaces.BaseCalculations;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Calculations.Entities
{
   public class OutputKgTest
   {
      private Mock<ISteamCharacteristicsService> MockSteam;
      private Mock<IDryDensity> MockDryDensity;
      private Mock<IWetDensity> MockWetDensity;
      private GasDensityData Data;
      public OutputKgTest()
      {
         MockSteam = new Mock<ISteamCharacteristicsService>();
         MockSteam.Setup(p => p.GetCharacteristics()).Returns(TestHelper.SteamCharacteristicsData());

         MockDryDensity = new Mock<IDryDensity>();
         MockWetDensity = new Mock<IWetDensity>();

         Data = new GasDensityData
         {
            CharacteristicsDg = TestHelper.CharacteristicsDgData(),
            CharacteristicsKg = TestHelper.CharacteristicsKgData(),
            Kip = TestHelper.DevicesKipData(),
            Pressure = TestHelper.PressureData(),
         };
      }
      [Fact]
      public void OutputKg()
      {

      }
   }
}
