using Business.BusinessModels.BaseCalculations.Production;
using Business.BusinessModels.Calculations;
using Business.BusinessModels.DataForCalculations;
using Business.DTO;
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
      private Mock<ICokeCbConsumptionDryCalc> MockCbDry;
      private Mock<ICalculation<OutputKgDTO>> MockOutputKG;

      private Data Data;
      public OutputKgTest()
      {
         MockCbDry = new Mock<ICokeCbConsumptionDryCalc>();
         var cbDry = new CokeCbConsumptionDryCalc(SetupHelper.DefaultDryCokeSetup().Object);
         MockCbDry.Setup(p => p.CalcEntity(It.IsAny<AmmountCb>()))
            .Returns((AmmountCb cb) => cbDry.CalcEntity(cb));

         MockOutputKG = new Mock<ICalculation<OutputKgDTO>>();
         var outputKg = new DefaultOutputKG(SetupHelper.WetGasDensityDefaultSetup().Object, SetupHelper.DefaultQcRcSetup().Object, 
                                         SetupHelper.Qn4000Setup().Object, MockCbDry.Object);

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
