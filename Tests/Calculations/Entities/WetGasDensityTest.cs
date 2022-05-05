using Business.BusinessModels.BaseCalculations;
using Business.BusinessModels.Calculations;
using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.Interfaces;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.BaseCalculations.Density;
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
      private Data Data;
      public WetGasDensityTest()
      {
         MockSteam = new Mock<ISteamCharacteristicsService>();
         MockSteam.Setup(p => p.GetCharacteristics()).Returns(TestHelper.SteamCharacteristicsData());

         MockDryDensity = new Mock<IDryDensity>();
         MockWetDensity = new Mock<IWetDensity>();

         Data = new Data
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
            Cu =
            {
               Cu1 = 0.4857840419m,
               Cu2 = 0.4418307183m,
            },
            Kc2 =
            {
               Cb1 = 0.4591238375m,
               Cb2 = 0.4645476338m,
               Cb3 = 0.4403959960m,
               Cb4 = 0.4332943460m,
            },
            CpsPpk =
            {
               Pko =
               {
                  Pkp = 0.4889691785m,
                  Uvtp = 0.4893950244m,
               },
               Spo = 0.4789630264m,
            },
            Gsuf = 0.4811577412m,
            Kc1 =
            {
               Cb1 = 1.2019043517m,
               Cb2 = 1.2019043517m,
               Cb3 = 1.2914997647m,
               Cb4 = 1.2342532350m,
            },
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
