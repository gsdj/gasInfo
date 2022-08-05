using Business.BusinessModels.BaseCalculations.Density;
using Business.BusinessModels.BaseCalculations.Qn;
using Business.BusinessModels.Calculations;
using Business.BusinessModels.Calculations.ConsGasQn;
using Business.BusinessModels.Calculations.QcRc;
using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.DTO.Models.Characteristics.Gas;
using Business.DTO.Models.QcRc;
using Business.Interfaces;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.BaseCalculations.Consumption;
using Business.Interfaces.BaseCalculations.Density;
using Business.Interfaces.Calculations;
using Business.Interfaces.Calculations.ConsGasQn;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Calculations.Entities
{
   public class ConsumptionDgTest
   {
      #region WetGas
      private Mock<ISteamCharacteristicsService> MockSteam;
      private Mock<IDryDensity> MockDryDensity;
      private Mock<IWetDensity> MockWetDensity;
      private Mock<ICalculation<DensityDTO>> MockCalcWetGas;
      #endregion
      #region ConsGasQnKc1
      private Mock<IQcRc> MockQcRc;
      private Mock<IConsGasQn<ConsGasQn1000>> MockConsGasQn1000;
      private Mock<ICalcQcRc<QcRcKc1>> MockQcRcKc1;
      private Mock<ICalcConsGasQnKc1> MockConsGasQnKc1;
      #endregion
      private Mock<ICalculation<ConsumptionDgDTO>> Target;
      private Data Data;
      public ConsumptionDgTest()
      {
         ConsGasQnSetup();
         WetGasSetup();
         TargetSetup();

         Data = new Data
         {
            CharacteristicsDg = TestCalculatedDataHelper.CharacteristicsDgData(),
            CharacteristicsKg = TestCalculatedDataHelper.CharacteristicsKgData(),
            Kip = TestCalculatedDataHelper.DevicesKipData(),
            Pressure = TestCalculatedDataHelper.PressureData(),
         };
      }
      private void ConsGasQnSetup()
      {
         MockQcRc = SetupHelper.DefaultQcRcSetup();

         MockQcRcKc1 = new Mock<ICalcQcRc<QcRcKc1>>();

         var qcrcKc1Calc = new CalcQcRcKc1(MockQcRc.Object);

         MockConsGasQn1000 = SetupHelper.Qn1000Setup();

         var consqnKc1 = new CalcConsQnKc1(MockQcRcKc1.Object, MockConsGasQn1000.Object);

         MockConsGasQnKc1 = new Mock<ICalcConsGasQnKc1>();
         MockConsGasQnKc1.Setup(p => p.Calc(It.IsAny<QcRcDgData>()))
            .Returns((QcRcDgData data) =>
            consqnKc1.Calc(data));

         MockConsGasQnKc1.Setup(p => p.Calc(It.IsAny<QcRcKc1>(), It.IsAny<CharacteristicsDG>()))
            .Returns((QcRcKc1 qcrc, CharacteristicsDG cGas) =>
            consqnKc1.Calc(qcrc, cGas));

         MockConsGasQnKc1.Setup(p => p.CalcQcRcKc1.Calc(It.IsAny<QcRcDgData>()))
            .Returns((QcRcDgData data) =>
            qcrcKc1Calc.Calc(data));
      }
      private void WetGasSetup()
      {
         MockSteam = new Mock<ISteamCharacteristicsService>();
         MockSteam.Setup(p => p.GetCharacteristics()).Returns(TestCalculatedDataHelper.SteamCharacteristicsData());

         MockDryDensity = new Mock<IDryDensity>();
         MockWetDensity = new Mock<IWetDensity>();

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
      }
      private void TargetSetup()
      {
         Target = new Mock<ICalculation<ConsumptionDgDTO>>();

         var consDgCalc = new CalcConsumptionDg(MockCalcWetGas.Object, MockConsGasQnKc1.Object/*, MockQcRcKc1.Object*/);

         Target.Setup(p => p.CalcEntity(It.IsAny<Data>()))
            .Returns((Data data) => consDgCalc.CalcEntity(data));
      }
      private ConsumptionDgDTO ExpectedObject()
      {
         return new ConsumptionDgDTO
         {
            Date = new DateTime(2019, 1, 1),
            QcRc =
            {
               Cb1 = { Value = 890813.5542703931m },
               Cb2 = { Value = 1023708.4705457035m },
               Cb3 = { Value = 0.0m },
               Cb4 = { Value = 1037536.2120598189m },
            },
            ConsumptionDg =
            {
               Cb1 = 661010.3816752598m,
               Cb2 = 759622.3963990284m,
               Cb3 = 0.0m,
               Cb4 = 769882.9954347474m,
            },
            ConsumptionDgMk = 2190515.7735090356m,
         };
      }
      [Fact]
      public void ConsumptionDg()
      {
         var expected = JsonConvert.SerializeObject(ExpectedObject());

         var result = JsonConvert.SerializeObject(Target.Object.CalcEntity(Data));

         Assert.Equal(expected, result);
      }
   }
}
