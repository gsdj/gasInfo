using Business.BusinessModels.BaseCalculations.Density;
using Business.BusinessModels.Calculations;
using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.Interfaces;
using Business.Interfaces.BaseCalculations.Density;
using Business.Interfaces.Calculations;
using Moq;
using Newtonsoft.Json;
using System;
using Xunit;

namespace Tests.Calculations.Entities
{
   public class WetGasDensityTest
   {
      private Mock<ISteamCharacteristicsService> MockSteam;
      private Mock<ICalculation<DensityDTO>> MockCalcWetGas;
      private Mock<IDryDensity> MockDryDensity;
      private Mock<IWetDensity> MockWetDensity;
      private Data Data;
      public WetGasDensityTest()
      {
         MockSteam = new Mock<ISteamCharacteristicsService>();
         MockSteam.Setup(p => p.GetCharacteristics()).Returns(TestCalculatedDataHelper.SteamCharacteristicsData());

         MockDryDensity = new Mock<IDryDensity>();
         MockWetDensity = new Mock<IWetDensity>();

         Data = new Data
         {
            CharacteristicsDg = TestCalculatedDataHelper.CharacteristicsDgData(),
            CharacteristicsKg = TestCalculatedDataHelper.CharacteristicsKgData(),
            Kip = TestCalculatedDataHelper.DevicesKipData(),
            Pressure = TestCalculatedDataHelper.PressureData(),
         };
      }

      private DensityDTO ExpectedObject()
      {
         return new DensityDTO
         {
            Date = new DateTime(2019, 1, 1),
            Cu =
            {
               Cu1 = 0.4857833637m,
               Cu2 = 0.4418310713m,
            },
            Kc2 =
            {
               Cb1 = 0.4591195625m,
               Cb2 = 0.4645535516m,
               Cb3 = 0.4404038659m,
               Cb4 = 0.4332963959m,
            },
            CpsPpk =
            {
               Pko =
               {
                  Pkp = 0.4889692822m,
                  Uvtp = 0.4893951281m,
               },
               Spo = 0.4789632545m,
            },
            Gsuf = 0.4811593826m,
            Kc1 =
            {
               Cb1 = 1.2019030463m,
               Cb2 = 1.2019030463m,
               Cb3 = 1.2914997638m,
               Cb4 = 1.2342525678m,
            },
         };
      }

      [Fact]
      public void WetGasDensity()
      {
         var DryDensity = new DryDensity(MockSteam.Object);

         MockDryDensity.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns((decimal pkg, decimal PPa, decimal pOver, decimal temp) =>
            DryDensity.Calc(pkg, PPa, pOver, temp));

         MockDryDensity.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns((decimal pkg, decimal PPa, decimal pOver, decimal temp, decimal tempDo) =>
            DryDensity.Calc(pkg, PPa, pOver, temp, tempDo));

         var WetDensity = new WetDensity(MockSteam.Object);


         MockWetDensity.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns((decimal dryGas, decimal temp) =>
            WetDensity.Calc(dryGas, temp));

         var CalcWetGas = new CalcWetGasDensity(MockWetDensity.Object, MockDryDensity.Object);

         MockCalcWetGas = new Mock<ICalculation<DensityDTO>>();

         MockCalcWetGas.Setup(p => p.CalcEntity(It.IsAny<Data>()))
            .Returns((Data data) => CalcWetGas.CalcEntity(data));

         //var target = new CalcWetGasDensity(MockWetDensity.Object, MockDryDensity.Object);
         var target = MockCalcWetGas.Object;

         var expected = JsonConvert.SerializeObject(ExpectedObject());

         var result = JsonConvert.SerializeObject(target.CalcEntity(Data));

         Assert.Equal(expected, result);

      }
   }
}
