using BLL.Calculations.Entities.Consumption;
using BLL.DataHelpers;
using BLL.DTO;
using BLL.DTO.Consumption;
using BLL.Interfaces.Calculations;
using BLL.Interfaces.Calculations.ConsGasQn;
using Moq;
using Newtonsoft.Json;
using System;
using Xunit;

namespace Tests.Calculations.Entities
{
   public class ConsumptionDgTest
   {
      private Mock<ICalculations<DensityDTO>> MockCalcWetGas;
      private Mock<ICalcConsGasQnKc1> MockConsGasQnKc1;
      private ICalculations<ConsumptionDgDTO> Target;
      private Data Data;

      public ConsumptionDgTest()
      {
         MockCalcWetGas = SetupHelper.WetGasDensityDefaultSetup();
         MockConsGasQnKc1 = SetupHelper.ConsQnKc1DefaultSetup();
         Target = new DefaultConsumptionDg(MockCalcWetGas.Object, MockConsGasQnKc1.Object);

         Data = new Data
         {
            CharacteristicsDg = TestCalculatedDataHelper.CharacteristicsDgData(),
            CharacteristicsKg = TestCalculatedDataHelper.CharacteristicsKgData(),
            Kip = TestCalculatedDataHelper.DevicesKipData(),
            Pressure = TestCalculatedDataHelper.PressureData(),
         };
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

         var result = JsonConvert.SerializeObject(Target.CalcEntity(Data));

         Assert.Equal(expected, result);
      }
   }
}
