using Business.BusinessModels.BaseCalculations;
using Business.BusinessModels.BaseCalculations.Consumption;
using Business.BusinessModels.BaseCalculations.Density;
using Business.BusinessModels.BaseCalculations.Production;
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

      private Mock<IQcRc> MockQcRc;
      private Mock<ICalcQcRc<QcRcKc1>> MockQcRcKc1;
      private Mock<ICalcConsGasQnKc1> MockConsGasQnKc1;

      private Mock<ISteamCharacteristicsService> MockSteam;
      private IDryDensity DryDensity;
      private IWetDensity WetDensity;
      private ICalculation<DensityDTO> WetGasDensity;
      private ICalculation<ConsumptionDgPgDTO> ConsDgPg;
      private Mock<IConsGasQn<ConsGasQn1000>> MockConsGasQn1000;
      private Data Data;

      private Mock<IConsPg> MockConsPg;
      private Mock<IConsPgCb> MockConsPgCb;
      private Mock<ISpecificConsDgFv> MockUdConsDgFv;

      private Mock<IChargeConsFV<DefaultChargeConsFV>> ChargeConsFV;
      private Mock<IDryCokeProduction<DefaultDryCokeProduction>> dryCoke;
      private Mock<ICokeCbConsumptionFvCalc> MockCbFv;
      public ConsumtionDgPgTest()
      {
         MockSteam = new Mock<ISteamCharacteristicsService>();
         MockSteam.Setup(p => p.GetCharacteristics()).Returns(TestCalculatedDataHelper.SteamCharacteristicsData());

         MockConsGasQn1000 = new Mock<IConsGasQn<ConsGasQn1000>>();
         MockQcRc = new Mock<IQcRc>();

         DryDensity = new DryDensity(MockSteam.Object);
         WetDensity = new WetDensity(MockSteam.Object);
         WetGasDensity = new CalcWetGasDensity(WetDensity, DryDensity);

         MockQcRc.SetupProperty(p => p.SteamCharacteristicsService, MockSteam.Object);
         var qcrcDef = new DefaultQcRc(MockSteam.Object);
         var consGasQn1 = new ConsGasQn1000();

         MockQcRc.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.Is<bool>(p => false)))
            .Returns((decimal cons, decimal wetGas, decimal temp, decimal density, bool perHour) =>
            qcrcDef.Calc(cons, wetGas, temp, density, perHour));

         MockQcRc.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.Is<bool>(p => true)))
            .Returns((decimal cons, decimal wetGas, decimal temp, decimal density, bool perHour) =>
            qcrcDef.Calc(cons, wetGas, temp, density, perHour));

         MockConsGasQn1000.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns((decimal qcrc, decimal qn) => consGasQn1.Calc(qcrc, qn));

         ConsQnKc1Setup();

         MockConsPg = new Mock<IConsPg>();
         var consPg = new DefaultConsPg();
         MockConsPg.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns((decimal cons, decimal ppa, decimal pressure, decimal temp) => consPg.Calc(cons, ppa, pressure, temp));

         MockConsPgCb = new Mock<IConsPgCb>();
         var consPgCb = new DefaultConsPgCb();
         MockConsPgCb.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns((decimal consDg, decimal consPgKc, decimal kcSum) => consPgCb.Calc(consDg, consPgKc, kcSum));

         MockUdConsDgFv = new Mock<ISpecificConsDgFv>();
         var udConsDgFv = new DefaultSpecificConsDgFv();
         MockUdConsDgFv.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns((decimal consDg, decimal consPg, decimal consFv) => udConsDgFv.Calc(consDg, consPg, consFv));

         var DryCoke = new DefaultDryCokeProduction();

         dryCoke = new Mock<IDryCokeProduction<DefaultDryCokeProduction>>();
         dryCoke.Setup(p => p.Calc(It.IsAny<int>(), It.IsAny<decimal>()))
            .Returns((int cb, decimal cbCoef) => DryCoke.Calc(cb, cbCoef));

         var chargeConsFV = new DefaultChargeConsFV(dryCoke.Object);

         ChargeConsFV = new Mock<IChargeConsFV<DefaultChargeConsFV>>();
         ChargeConsFV.Setup(p => p.Calc(It.IsAny<int>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns((int cb, decimal cbCoef, decimal fvCoef) => chargeConsFV.Calc(cb, cbCoef, fvCoef));

         MockCbFv = new Mock<ICokeCbConsumptionFvCalc>();
         var cbFv = new CokeCbConsumptionFvCalc(ChargeConsFV.Object);

         MockCbFv.Setup(p => p.CalcEntities(It.IsAny<IEnumerable<AmmountCb>>()))
            .Returns((IEnumerable<AmmountCb> data) => cbFv.CalcEntities(data));

         MockCbFv.Setup(p => p.CalcEntity(It.IsAny<AmmountCb>()))
            .Returns((AmmountCb data) => cbFv.CalcEntity(data));


         Data = new OutputKgData
         {
            CharacteristicsDg = TestCalculatedDataHelper.CharacteristicsDgData(),
            CharacteristicsKg = TestCalculatedDataHelper.CharacteristicsKgData(),
            Kip = TestCalculatedDataHelper.DevicesKipData(),
            Pressure = TestCalculatedDataHelper.PressureData(),
            AmmountCb = TestDbDataHelper.AmmountCbData(),
         };

         ConsDgPg = new CalcConsumptionDgPg(WetGasDensity, MockConsPg.Object, MockConsPgCb.Object, MockConsGasQnKc1.Object, MockUdConsDgFv.Object, MockCbFv.Object);
      }

      //private void QcRcKc1Setup()
      //{
      //   MockQcRcKc1 = new Mock<ICalcQcRc<QcRcKc1>>();

      //   var qcrcKc1Calc = new CalcQcRcKc1(MockQcRc.Object);

      //   MockQcRcKc1.Setup(p => p.Calc(It.IsAny<QcRcData>()))
      //      .Returns((QcRcData data) =>
      //      qcrcKc1Calc.Calc(data));
      //}
      private void ConsQnKc1Setup()
      {
         MockQcRcKc1 = new Mock<ICalcQcRc<QcRcKc1>>();

         var qcrcKc1Calc = new CalcQcRcKc1(MockQcRc.Object);

         var consqnKc1 = new CalcConsQnKc1(MockQcRcKc1.Object, MockConsGasQn1000.Object);

         MockConsGasQnKc1 = new Mock<ICalcConsGasQnKc1>();
         MockConsGasQnKc1.Setup(p => p.Calc(It.IsAny<QcRcData>()))
            .Returns((QcRcData data) =>
            consqnKc1.Calc(data));

         MockConsGasQnKc1.Setup(p => p.Calc(It.IsAny<QcRcKc1>(), It.IsAny<CharacteristicsDG>()))
            .Returns((QcRcKc1 kc1, CharacteristicsDG kGas) =>
            consqnKc1.Calc(kc1, kGas));

         MockConsGasQnKc1.Setup(p => p.CalcQcRcKc1.Calc(It.IsAny<QcRcData>()))
            .Returns((QcRcData data) =>
            qcrcKc1Calc.Calc(data));
      }

      private ConsumptionDgPgDTO ExpectedObject()
      {
         return new ConsumptionDgPgDTO
         {
            Date = new DateTime(2019, 1, 1),
            ConsumptionDgCb =
            {
               Cb1 = 0.0m,
               Cb2 = 0.0m,
               Cb3 = 0.0m,
               Cb4 = 0.0m,
            },
            ConsumptionDgKc1 = 0.0m,
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
               Gru1 = 0.0m,
               Gru2 = 0.0m,
            },
            UdConsumptionPgGru =
            {
               Gru1 = 0.0m,
               Gru2 = 0.0m,
            },
            UdConsumptionKgFvCb =
            {
               Cb1 = 0.0m,
               Cb2 = 0.0m,
               Cb3 = 0.0m,
               Cb4 = 0.0m,
            },
            UdConsumptionKgFvKc1 = 0.0m,
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
