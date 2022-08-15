using Business.BusinessModels.BaseCalculations.Production;
using Business.BusinessModels.Calculations;
using Business.DTO;
using Business.Interfaces.BaseCalculations.Production;
using Business.Interfaces.Calculations;
using DataAccess.Entities;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests.Calculations.Entities
{
   public class DgPgChmkEbTest
   {
      private ICalcEbChmk Target;
      private Mock<ICokeCbConsumptionFvCalc> MockCbFv;
      public DgPgChmkEbTest()
      {
         MockCbFv = new Mock<ICokeCbConsumptionFvCalc>();
         var cbFv = new CokeCbConsumptionFvCalc(SetupHelper.DefaultChargeConsFvSetup().Object);

         MockCbFv.Setup(p => p.CalcEntities(It.IsAny<IEnumerable<AmmountCb>>()))
            .Returns((IEnumerable<AmmountCb> data) => cbFv.CalcEntities(data));

         MockCbFv.Setup(p => p.CalcEntity(It.IsAny<AmmountCb>()))
            .Returns((AmmountCb data) => cbFv.CalcEntity(data));

         Target = new CalcEbChmk(MockCbFv.Object);
      }
      private EbChmkDTO ExpectedObject()
      {
         return new EbChmkDTO
         {
            Date = new DateTime(2019, 1, 10),
            ConsumptionKc1 =
            {
               Cb1 = 9914000m,
               Cb2 = 10992000m,
               Cb3 = 0.0m,
               Cb4 = 11247000m,
            },
            ConsDgKc1Sum = 32153000m,
            UdConsumptionKc1 =
            {
               Cb1 = 140m,
               Cb2 = 118m,
               Cb3 = 0.0m,
               Cb4 = 120m,
            },
            UdConsKc1Sum = 125,
            ConsumptionGru =
            {
               Gru1 = 157000m,
               Gru2 = 197000m,
            },
            ConsPgUpc = 354000,
            UdConsumptionGru =
            {
               Gru1 = 6.12m,
               Gru2 = 5.12m,
            },
         };
      }
      [Fact]
      public void EbChmk()
      {
         var expected = JsonConvert.SerializeObject(ExpectedObject());

         var result = JsonConvert.SerializeObject(Target.CalcEntity(TestDbDataHelper.AmmountCbDataList(), TestDbDataHelper.DgPgChmkEbData()));

         Assert.Equal(expected, result);
      }
   }
}
