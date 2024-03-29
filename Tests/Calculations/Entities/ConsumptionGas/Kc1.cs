﻿using BLL.Calculations.Base.Qn;
using BLL.Calculations.Entities.ConsGasQn;
using BLL.Calculations.Entities.QcRc;
using BLL.DataHelpers;
using BLL.Interfaces.BaseCalculations;
using BLL.Interfaces.BaseCalculations.Consumption;
using BLL.Interfaces.Calculations;
using BLL.Interfaces.Calculations.ConsGasQn;
using BLL.Models.BaseModels.General;
using BLL.Models.BaseModels.QcRc;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Tests.Calculations.Entities.ConsumptionGas
{
   public class Kc1
   {
      private Mock<IQcRc> MockQcRc;
      private Mock<IConsGasQn<ConsGasQn1000>> MockConsGasQn1000;
      private Mock<ICalcQcRc<QcRcKc1>> MockQcRcKc1;
      private Mock<ICalcConsGasQnKc1> Target;
      public Kc1()
      {
         MockQcRc = SetupHelper.DefaultQcRcSetup();
         MockConsGasQn1000 = SetupHelper.Qn1000Setup();
         QcRcKc1Setup();
         ConsQnKc1Setup();
      }
      private void QcRcKc1Setup()
      {
         MockQcRcKc1 = new Mock<ICalcQcRc<QcRcKc1>>();

         var qcrcKc1Calc = new CalcQcRcKc1(MockQcRc.Object);

         MockQcRcKc1.Setup(p => p.Calc(It.IsAny<QcRcData>()))
            .Returns((QcRcData data) =>
            qcrcKc1Calc.Calc(data));
      }
      private void ConsQnKc1Setup()
      {
         var consqnKc1 = new CalcConsQnKc1(MockQcRcKc1.Object, MockConsGasQn1000.Object);

         Target = new Mock<ICalcConsGasQnKc1>();
         Target.Setup(p => p.Calc(It.IsAny<QcRcData>()))
            .Returns((QcRcData data) =>
            consqnKc1.Calc(data));
      }
      private CbKc ExpectedObject()
      {
         return new CbKc
         {
            
            Cb1 = 661011.1162919075m,
            Cb2 = 759623.2406085504m,
            Cb3 = 0.0m,
            Cb4 = 769883.4182911777m,
         };
      }

      [Fact]
      public void ConsGasKc1()
      {
         var Data = new QcRcDgData
         {
            CharacteristicsDg = TestCalculatedDataHelper.CharacteristicsDgData(),
            Kip = TestCalculatedDataHelper.DevicesKipData(),
            WetGas = TestCalculatedDataHelper.DensityDTOData(),
         };

         var expected = JsonConvert.SerializeObject(ExpectedObject());

         var result = JsonConvert.SerializeObject(Target.Object.Calc(Data));

         Assert.Equal(expected, result);
      }
   }
}
