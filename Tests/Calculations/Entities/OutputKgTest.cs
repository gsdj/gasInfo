using Business.BusinessModels.BaseCalculations;
using Business.BusinessModels.BaseCalculations.Density;
using Business.BusinessModels.BaseCalculations.Production;
using Business.BusinessModels.BaseCalculations.Qn;
using Business.BusinessModels.Calculations;
using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.Interfaces;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.BaseCalculations.Consumption;
using Business.Interfaces.BaseCalculations.Density;
using Business.Interfaces.BaseCalculations.Production;
using Business.Interfaces.Calculations;
using DataAccess.Entities;
using Moq;
using Newtonsoft.Json;
using System;
using Xunit;

namespace Tests.Calculations.Entities
{
   public class OutputKgTest
   {
      private Mock<IQcRc> MockQcRc;
      private Mock<ISteamCharacteristicsService> MockSteam;
      private Mock<IDryDensity> MockDryDensity;
      private Mock<IWetDensity> MockWetDensity;
      private Mock<ICalculation<DensityDTO>> MockCalcWetGas;
      private Mock<IConsGasQn<ConsGasQn4000>> MockConsGasQn4000;
      private Mock<IDryCokeProduction<DefaultDryCokeProduction>> MockDryCoke;
      private Mock<ICokeCbConsumptionDryCalc> MockCbDry;
      private Mock<ICalculation<OutputKgDTO>> MockOutputKG;

      private Data Data;
      public OutputKgTest()
      {
         MockSteam = new Mock<ISteamCharacteristicsService>();
         MockSteam.Setup(p => p.GetCharacteristics()).Returns(TestCalculatedDataHelper.SteamCharacteristicsData());

         MockDryCoke = new Mock<IDryCokeProduction<DefaultDryCokeProduction>>();
         MockDryCoke.Setup(p => p.Calc(It.IsAny<int>(), It.IsAny<decimal>()))
            .Returns((int cb, decimal cbCoef) => new DefaultDryCokeProduction().Calc(cb, cbCoef));

         MockCbDry = new Mock<ICokeCbConsumptionDryCalc>();
         var cbDry = new CokeCbConsumptionDryCalc(MockDryCoke.Object);
         MockCbDry.Setup(p => p.CalcEntity(It.IsAny<AmmountCb>()))
            .Returns((AmmountCb cb) => cbDry.CalcEntity(cb));

         MockQcRc = SetupHelper.DefaultQcRcSetup();

         MockConsGasQn4000 = new Mock<IConsGasQn<ConsGasQn4000>>();
         var consGasQn4 = new ConsGasQn4000();
         MockConsGasQn4000.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns((decimal qcrc, decimal qn) => consGasQn4.Calc(qcrc, qn));

         MockDryDensity = new Mock<IDryDensity>();
         MockWetDensity = new Mock<IWetDensity>();

         var DryDensity1 = new DryDensity(MockSteam.Object);

         MockDryDensity.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns((decimal pkg, decimal PPa, decimal pOver, decimal temp) =>
            DryDensity1.Calc(pkg, PPa, pOver, temp));

         MockDryDensity.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns((decimal pkg, decimal PPa, decimal pOver, decimal temp, decimal tempDo) =>
            DryDensity1.Calc(pkg, PPa, pOver, temp, tempDo));

         var WetDensity = new WetDensity(MockSteam.Object);

         MockWetDensity.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns((decimal dryGas, decimal temp) =>
            WetDensity.Calc(dryGas, temp));

         var CalcWetGas = new CalcWetGasDensity(MockWetDensity.Object, MockDryDensity.Object);

         MockCalcWetGas = new Mock<ICalculation<DensityDTO>>();

         MockCalcWetGas.Setup(p => p.CalcEntity(It.IsAny<Data>()))
            .Returns((Data data) => CalcWetGas.CalcEntity(data));

         MockOutputKG = new Mock<ICalculation<OutputKgDTO>>();
         var outputKg = new CalcOutputKG(MockCalcWetGas.Object,MockQcRc.Object, MockConsGasQn4000.Object, MockCbDry.Object);
         MockOutputKG.Setup(p => p.CalcEntity(It.IsAny<Data>()))
            .Returns((Data data) => outputKg.CalcEntity(data));

         Data = new OutputKgData
         {
            CharacteristicsDg = TestCalculatedDataHelper.CharacteristicsDgData(),
            CharacteristicsKg = TestCalculatedDataHelper.CharacteristicsKgData(),
            Kip = TestCalculatedDataHelper.DevicesKipData(),
            Pressure = TestCalculatedDataHelper.PressureData(),
            AmmountCb = TestDbDataHelper.AmmountCbData(),
         };
      }
      private OutputKgDTO ExpectedObject()
      {
         return new OutputKgDTO
         {
            Date = new DateTime(2019, 01, 01),
            QcRcCu1 = 1661170.7720061143m,
            Cu14000 = 1495053.6948055029m,
            Cu1Cb16 = 297.78655397027543278538585284m,
            QcRcCu2 = 695312.6477782261m,
            Cu24000 = 625781.3830004035m,
            Cu2Cb78 = 392.78911419029915519344050333m,
            PrMk = 2356483.4197843404m,
            PrMk4000 = 2120835.0778059064m,
            OutCgSh = 320.67161789564279297629994046m,
         };
      }
      [Fact]
      public void OutputKg()
      {
         var expected = JsonConvert.SerializeObject(ExpectedObject());
         var result = JsonConvert.SerializeObject(MockOutputKG.Object.CalcEntity(Data));

         Assert.Equal(expected, result);
      }
   }
}
