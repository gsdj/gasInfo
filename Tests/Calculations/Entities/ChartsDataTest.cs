using Business.BusinessModels.BaseCalculations;
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
using Xunit;

namespace Tests.Calculations.Entities
{
   public class ChartsDataTest
   {

      private Mock<IQcRc> MockQcRc;
      private Mock<ICalcQcRc<QcRcKc2>> MockQcRcKc2;
      private Mock<ICalcConsGasQnKc2> MockConsGasQnKc2;

      private Mock<ICalcQcRc<CpsPpkQcRc>> MockQcRcCpsPpk;
      private Mock<ICalcConsGasQnCpsPpk> MockConsGasQnCpsPpk;

      private Mock<ISteamCharacteristicsService> MockSteam;
      private IDryDensity DryDensity;
      private IWetDensity WetDensity;
      private ICalculation<DensityDTO> WetGasDensity;
      private ICalculation<ChartYearDTO> ChartYearData;
      private ICalculation<ChartMonthDTO> ChartMonthData;
      private Mock<IConsGasQn<ConsGasQn4000>> MockConsGasQn4000;

      private Mock<IDryCokeProduction<DefaultDryCokeProduction>> MockDryCoke;
      private Mock<ICokeCbConsumptionDryCalc> MockCbDry;

      private Data Data;
      public ChartsDataTest()
      {
         MockSteam = new Mock<ISteamCharacteristicsService>();
         MockSteam.Setup(p => p.GetCharacteristics()).Returns(TestCalculatedDataHelper.SteamCharacteristicsData());

         MockConsGasQn4000 = new Mock<IConsGasQn<ConsGasQn4000>>();
         MockQcRc = new Mock<IQcRc>();

         DryDensity = new DryDensity(MockSteam.Object);
         WetDensity = new WetDensity(MockSteam.Object);
         WetGasDensity = new CalcWetGasDensity(WetDensity, DryDensity);

         MockQcRc.SetupProperty(p => p.SteamCharacteristicsService, MockSteam.Object);
         var qcrcDef = new DefaultQcRc(MockSteam.Object);
         var consGasQn4 = new ConsGasQn4000();

         MockQcRc.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.Is<bool>(p => false)))
            .Returns((decimal cons, decimal wetGas, decimal temp, decimal density, bool perHour) =>
            qcrcDef.Calc(cons, wetGas, temp, density, perHour));

         MockQcRc.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.Is<bool>(p => true)))
            .Returns((decimal cons, decimal wetGas, decimal temp, decimal density, bool perHour) =>
            qcrcDef.Calc(cons, wetGas, temp, density, perHour));

         MockConsGasQn4000.Setup(p => p.Calc(It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns((decimal qcrc, decimal qn) => consGasQn4.Calc(qcrc, qn));

         //QcRcKc2Setup();
         ConsQnKc2Setup();
         QcRcCpsPpkSetup();
         ConsQnCpsPpkSetup();

         

         Data = new ChartData
         {
            CharacteristicsDg = TestCalculatedDataHelper.CharacteristicsDgData(),
            CharacteristicsKg = TestCalculatedDataHelper.CharacteristicsKgData(),
            Kip = TestCalculatedDataHelper.DevicesKipData(),
            Pressure = TestCalculatedDataHelper.PressureData(),
            AmmountCb = TestDbDataHelper.AmmountCbData(),
            Asdue = TestCalculatedDataHelper.AsdueDTOData(),
            Quality = TestCalculatedDataHelper.QualityData(),
            KgChmkEb = TestDbDataHelper.KgChmkEbData(),
         };

         MockDryCoke = new Mock<IDryCokeProduction<DefaultDryCokeProduction>>();
         MockDryCoke.Setup(p => p.Calc(It.IsAny<int>(), It.IsAny<decimal>()))
            .Returns((int cb, decimal cbCoef) => new DefaultDryCokeProduction().Calc(cb, cbCoef));

         MockCbDry = new Mock<ICokeCbConsumptionDryCalc>();
         var cbDry = new CokeCbConsumptionDryCalc(MockDryCoke.Object);
         MockCbDry.Setup(p => p.CalcEntity(It.IsAny<AmmountCb>()))
            .Returns((AmmountCb cb) => cbDry.CalcEntity(cb));

         ChartMonthData = new CalcChartMonth(WetGasDensity, MockConsGasQnKc2.Object, MockConsGasQnCpsPpk.Object, MockCbDry.Object);
         ChartYearData = new CalcChartYear(WetGasDensity, MockConsGasQnKc2.Object, MockConsGasQnCpsPpk.Object, MockCbDry.Object);
      }

      private void QcRcKc2Setup()
      {
         MockQcRcKc2 = new Mock<ICalcQcRc<QcRcKc2>>();

         var qcrcKc2Calc = new CalcQcRcKc2(MockQcRc.Object);

         MockQcRcKc2.Setup(p => p.Calc(It.IsAny<QcRcData>()))
            .Returns((QcRcData data) =>
            qcrcKc2Calc.Calc(data));
      }
      private void ConsQnKc2Setup()
      {
         MockQcRcKc2 = new Mock<ICalcQcRc<QcRcKc2>>();

         var qcrcKc2Calc = new CalcQcRcKc2(MockQcRc.Object);

         var consqnKc2 = new CalcConsQnKc2(MockQcRcKc2.Object, MockConsGasQn4000.Object);

         MockConsGasQnKc2 = new Mock<ICalcConsGasQnKc2>();
         MockConsGasQnKc2.Setup(p => p.Calc(It.IsAny<QcRcData>()))
            .Returns((QcRcData data) =>
            consqnKc2.Calc(data));

         MockConsGasQnKc2.Setup(p => p.Calc(It.IsAny<QcRcKc2>(), It.IsAny<CharacteristicsKG>()))
            .Returns((QcRcKc2 kc2, CharacteristicsKG kGas) =>
            consqnKc2.Calc(kc2, kGas));

         MockConsGasQnKc2.Setup(p => p.CalcQcRcKc2.Calc(It.IsAny<QcRcData>()))
            .Returns((QcRcData data) =>
            qcrcKc2Calc.Calc(data));
      }
      private void QcRcCpsPpkSetup()
      {
         MockQcRcCpsPpk = new Mock<ICalcQcRc<CpsPpkQcRc>>();

         var qcrcKc2Calc = new CalcQcRcCpsPpk(MockQcRc.Object);

         MockQcRcCpsPpk.Setup(p => p.Calc(It.IsAny<QcRcData>()))
            .Returns((QcRcData data) =>
            qcrcKc2Calc.Calc(data));
      }
      private void ConsQnCpsPpkSetup()
      {
         // чё нить придумать с qcrc и cons
         MockQcRcCpsPpk = new Mock<ICalcQcRc<CpsPpkQcRc>>();

         var qcrcCpsPpkCalc = new CalcQcRcCpsPpk(MockQcRc.Object);

         var consqnCpsPpk = new CalcConsQnCpsPpk(MockQcRcCpsPpk.Object, MockConsGasQn4000.Object);

         MockConsGasQnCpsPpk = new Mock<ICalcConsGasQnCpsPpk>();
         MockConsGasQnCpsPpk.Setup(p => p.Calc(It.IsAny<QcRcData>()))
            .Returns((QcRcData data) =>
            consqnCpsPpk.Calc(data));

         MockConsGasQnCpsPpk.Setup(p => p.Calc(It.IsAny<CpsPpkQcRc>(), It.IsAny<CharacteristicsKG>()))
            .Returns((CpsPpkQcRc qcrc, CharacteristicsKG kGas) =>
            consqnCpsPpk.Calc(qcrc, kGas));

         MockConsGasQnCpsPpk.Setup(p => p.CalcQcRcCpsPpk.Calc(It.IsAny<QcRcData>()))
            .Returns((QcRcData data) =>
            qcrcCpsPpkCalc.Calc(data));

         MockConsGasQnCpsPpk.Setup(p => p.CalcQcRcCpsPpk.QcRc.Calc(It.IsAny<decimal>(), It.IsAny<decimal>(),
            It.IsAny<decimal>(), It.IsAny<decimal>(), It.Is<bool>(p => !p)))
            .Returns((decimal cons, decimal wetGas, decimal temp, decimal density, bool perHour) =>
            qcrcCpsPpkCalc.QcRc.Calc(cons, wetGas, temp, density, false));

         MockConsGasQnCpsPpk.Setup(p => p.ConsGasQn.Calc(It.IsAny<decimal>(), It.IsAny<decimal>()))
            .Returns((decimal qcrc, decimal qn) => consqnCpsPpk.ConsGasQn.Calc(qcrc, qn));
      }

      private ChartMonthDTO ExpectedObjectMonth()
      {
         return new ChartMonthDTO
         {
            Date = new DateTime(2019, 1, 1),
            TheorOutKg = 0.0m,
            OperOutKg = 0.0m,
            TradeOutKg = 0.0m,
            TradeChmkOutKg = 0.0m,
         };
      }
      private ChartYearDTO ExpectedObjectYear()
      {
         return new ChartYearDTO
         {
            Date = new DateTime(2019, 1, 1),
            TradeGasMK = 0.0m,
            TradeGasEB = 0.0m,
            TradeGasAsdue = 0.0m,
            TradeGasTn = 0.0m,
            TradeGasV = 0.0m,
            TradeGasDev = 0.0m,
         };
      }

      [Fact]
      public void ChartMonth()
      {
         var expected = JsonConvert.SerializeObject(ExpectedObjectMonth());

         var result = JsonConvert.SerializeObject(ChartMonthData.CalcEntity(Data));

         Assert.Equal(expected, result);
      }
      [Fact]
      public void ChartYear()
      {
         var expected = JsonConvert.SerializeObject(ExpectedObjectYear());

         var result = JsonConvert.SerializeObject(ChartYearData.CalcEntity(Data));

         Assert.Equal(expected, result);
      }
   }
}
