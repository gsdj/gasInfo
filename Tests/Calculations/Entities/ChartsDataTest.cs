using BLL.Calculations.Base.Production;
using BLL.Calculations.Entities.Charts;
using BLL.DataHelpers;
using BLL.DTO;
using BLL.DTO.Charts;
using BLL.Interfaces.BaseCalculations.Production;
using BLL.Interfaces.Calculations;
using BLL.Interfaces.Calculations.ConsGasQn;
using DA.Entities;
using Moq;
using Newtonsoft.Json;
using System;
using Xunit;

namespace Tests.Calculations.Entities
{
   public class ChartsDataTest
   {
      private Mock<ICalcConsGasQnKc2> MockConsGasQnKc2;
      private Mock<ICalcConsGasQnCpsPpk> MockConsGasQnCpsPpk;

      private ICalculation<DensityDTO> WetGasDensity;
      private ICalculation<ChartYearDTO> ChartYearData;
      private ICalculation<ChartMonthDTO> ChartMonthData;
      private Mock<ICokeCbConsumptionDryCalc> MockCbDry;

      private Data Data;
      public ChartsDataTest()
      {
         Data = new ChartData
         {
            CharacteristicsDg = TestCalculatedDataHelper.CharacteristicsDgData2020(),
            CharacteristicsKg = TestCalculatedDataHelper.CharacteristicsKgData2020(),
            Kip = TestCalculatedDataHelper.DevicesKipData2020(),
            Pressure = TestCalculatedDataHelper.PressureData2020(),
            AmmountCb = TestDbDataHelper.AmmountCbData2020(),
            Asdue = TestCalculatedDataHelper.AsdueDTOData(),
            Quality = TestCalculatedDataHelper.QualityData2020(),
            KgChmkEb = TestDbDataHelper.KgChmkEbData(),
         };


         MockCbDry = new Mock<ICokeCbConsumptionDryCalc>();
         var cbDry = new CokeCbConsumptionDryCalc(SetupHelper.DefaultDryCokeSetup().Object);
         MockCbDry.Setup(p => p.CalcEntity(It.IsAny<AmmountCb>()))
            .Returns((AmmountCb cb) => cbDry.CalcEntity(cb));

         WetGasDensity = SetupHelper.WetGasDensityDefaultSetup().Object;
         MockConsGasQnKc2 = SetupHelper.ConsQnKc2DefaultSetup();
         MockConsGasQnCpsPpk = SetupHelper.ConsQnCpsPpkDefaultSetup();

         ChartMonthData = new DefaultChartMonth(WetGasDensity, MockConsGasQnKc2.Object, MockConsGasQnCpsPpk.Object, MockCbDry.Object);
         ChartYearData = new DefaultChartYear(WetGasDensity, MockConsGasQnKc2.Object, MockConsGasQnCpsPpk.Object, MockCbDry.Object);
      }

      private ChartMonthDTO ExpectedObjectMonth()
      {
         return new ChartMonthDTO
         {
            Date = new DateTime(2019, 1, 1),
            TheorOutKg = 339.0m,
            OperOutKg = 390.0m,
            TradeOutKg = 347.0m,
            TradeChmkOutKg = 343.0m,
         };
      }
      private ChartYearDTO ExpectedObjectYear()
      {
         return new ChartYearDTO
         {
            Date = new DateTime(2019, 1, 1),
            TradeGasMK = 80444.0m,
            TradeGasEB = 67532.0m,
            TradeGasAsdue = 68560.0m,
            TradeGasTn = 65229.0m,
            TradeGasV = 66453.0m,
            TradeGasDev = 98.0m,
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
