using Business.BusinessModels.BaseCalculations.Consumption;
using Business.BusinessModels.BaseCalculations.Production;
using Business.BusinessModels.Calculations;
using Business.BusinessModels.DataForCalculations;
using Business.DTO;
using Business.Interfaces.BaseCalculations.Consumption;
using Business.Interfaces.BaseCalculations.Production;
using Business.Interfaces.Calculations;
using Business.Interfaces.Calculations.ConsGasQn;
using DataAccess.Entities;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests.Calculations.Entities
{
   public class ConsumtionDgPgTest
   {
      private Mock<ICalcConsGasQnKc1> MockConsGasQnKc1;
      private Mock<ICalculation<DensityDTO>> MockCalcWetGas;
      private Mock<IConsPg> MockConsPg;
      private Mock<IConsPgCb> MockConsPgCb;
      private Mock<ISpecificConsDgFv> MockUdConsDgFv;
      private Mock<ICokeCbConsumptionFvCalc> MockCbFv;

      private ICalculation<ConsumptionDgPgDTO> ConsDgPg;
      private Data Data;
      
      public ConsumtionDgPgTest()
      {
         MockConsGasQnKc1 = SetupHelper.ConsQnKc1DefaultSetup();
         MockCalcWetGas = SetupHelper.WetGasDensityDefaultSetup();
         ConsPgSetup();
         ConsPgCbSetup();
         SpecificConsDgFvSetup();
         CbFvSetup();

         Data = new OutputKgData
         {
            CharacteristicsDg = TestCalculatedDataHelper.CharacteristicsDgData(),
            CharacteristicsKg = TestCalculatedDataHelper.CharacteristicsKgData(),
            Kip = TestCalculatedDataHelper.DevicesKipData(),
            Pressure = TestCalculatedDataHelper.PressureData(),
            AmmountCb = TestDbDataHelper.AmmountCbData(),
         };

         ConsDgPg = new CalcConsumptionDgPg(MockCalcWetGas.Object, MockConsPg.Object, MockConsPgCb.Object, MockConsGasQnKc1.Object, MockUdConsDgFv.Object, MockCbFv.Object);
      }

      private void ConsPgSetup()
      {
         MockConsPg = new Mock<IConsPg>();
         var consPg = new DefaultConsPg();
         MockConsPg.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns((decimal cons, decimal ppa, decimal pressure, decimal temp) => consPg.Calc(cons, ppa, pressure, temp));
      }
      private void ConsPgCbSetup()
      {
         MockConsPgCb = new Mock<IConsPgCb>();
         var consPgCb = new DefaultConsPgCb();
         MockConsPgCb.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns((decimal consDg, decimal consPgKc, decimal kcSum) => consPgCb.Calc(consDg, consPgKc, kcSum));
      }
      private void SpecificConsDgFvSetup()
      {
         MockUdConsDgFv = new Mock<ISpecificConsDgFv>();
         var udConsDgFv = new DefaultSpecificConsDgFv();
         MockUdConsDgFv.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns((decimal consDg, decimal consPg, decimal consFv) => udConsDgFv.Calc(consDg, consPg, consFv));
      }
      private void CbFvSetup()
      {
         MockCbFv = new Mock<ICokeCbConsumptionFvCalc>();
         var cbFv = new CokeCbConsumptionFvCalc(SetupHelper.DefaultChargeConsFvSetup().Object);

         MockCbFv.Setup(p => p.CalcEntities(It.IsAny<IEnumerable<AmmountCb>>()))
            .Returns((IEnumerable<AmmountCb> data) => cbFv.CalcEntities(data));

         MockCbFv.Setup(p => p.CalcEntity(It.IsAny<AmmountCb>()))
            .Returns((AmmountCb data) => cbFv.CalcEntity(data));
      }
      private ConsumptionDgPgDTO ExpectedObject()
      {
         return new ConsumptionDgPgDTO
         {
            Date = new DateTime(2019, 1, 1),
            ConsumptionDgCb =
            {
               Cb1 = 661010.3816752598m,
               Cb2 = 759622.3963990284m,
               Cb3 = 0.0m,
               Cb4 = 769882.9954347474m,
            },
            ConsumptionDgKc1 = 2190515.7735090356m,
            ConsumptionPgCb =
            {
               Cb1 = 0.0m,
               Cb2 = 0.0m,
               Cb3 = 0.0m,
               Cb4 = 0.0m,
            },
            ConsumptionPgKc1 = 0.0m,
            ConsumptionPgGru =
            {
               Gru1 = 19475.2558470305m,
               Gru2 = 17220.0938146890m,
            },
            UdConsumptionPgGru =
            {
               Gru1 = 8438.832715421953966161283234m,
               Gru2 = 5627.0138566221786548070927936m,
            },
            UdConsumptionKgFvCb =
            {
               Cb1 = 89.8087527072m,
               Cb2 = 78.2876229258m,
               Cb3 = 0.0m,
               Cb4 = 83.1172367055m,
            },
            UdConsumptionKgFvKc1 = 83.2079957164m,
         };
      }

      [Fact]
      public void CounsumptionDgPg()
      {

         var expected = JsonConvert.SerializeObject(ExpectedObject());

         var result = JsonConvert.SerializeObject(ConsDgPg.CalcEntity(Data));

         Assert.Equal(expected, result);
      }
   }
}
