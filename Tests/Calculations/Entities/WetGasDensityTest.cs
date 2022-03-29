using Business.BusinessModels.BaseCalculations;
using Business.BusinessModels.Calculations;
using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.Interfaces;
using Business.Interfaces.BaseCalculations;
using Moq;
using Newtonsoft.Json;
using System;
using Xunit;

namespace Tests.Calculations.Entities
{
   public class WetGasDensityTest
   {
      private Mock<ISteamCharacteristicsService> MockSteam;
      private Mock<IDryDensity> MockDryDensity;
      private Mock<IWetDensity> MockWetDensity;
      private GasDensityData Data;
      public WetGasDensityTest()
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

      private DensityDTO ExpectedObject()
      {
         return new DensityDTO
         {
            Date = new DateTime(2019, 1, 1),
            Cu1 = 0.485784041914365m,
            Cu2 = 0.441830718254958m,
            Cb5 = 0.459123837535828m,
            Cb6 = 0.464547633814450m,
            Cb7 = 0.440395995998558m,
            Cb8 = 0.433294345998558m,
            Pkc = 0.488969178498195m,
            Uvtp = 0.489395024423076m,
            Spo = 0.478963026366234m,
            Gsuf = 0.481157741209795m,
            Cb1 = 1.201904351654335m,
            Cb2 = 1.201904351654335m,
            Cb3 = 1.291499764653240m,
            Cb4 = 1.234253235022711m,
         };
      }

      [Fact]
      public void WetGasDensity()
      {
         MockDryDensity.SetupProperty(p => p.SteamCharacteristicsService, MockSteam.Object);

         var DryDensity = new DryDensity(MockSteam.Object);

         MockDryDensity.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns((decimal pkg, decimal PPa, decimal pOver, decimal temp) =>
            DryDensity.Calc(pkg, PPa, pOver, temp));
         MockDryDensity.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns((decimal pkg, decimal PPa, decimal pOver, decimal temp, decimal tempDo) =>
            DryDensity.Calc(pkg, PPa, pOver, temp, tempDo));

         var WetDensity = new WetDensity(MockSteam.Object);

         MockWetDensity.SetupProperty(p => p.SteamCharacteristicsService, MockSteam.Object);

         MockWetDensity.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns((decimal dryGas, decimal temp) =>
            WetDensity.Calc(dryGas, temp));

         var target = new CalcWetGasDensity(MockWetDensity.Object, MockDryDensity.Object);

         var expected = JsonConvert.SerializeObject(ExpectedObject());

         var result = JsonConvert.SerializeObject(target.CalcEntity(Data));

         Assert.Equal(expected, result);

      }
   }
}
