using Business.BusinessModels.BaseCalculations;
using Business.BusinessModels.BaseCalculations.Qn;
using Business.BusinessModels.Calculations.ConsGasQn;
using Business.BusinessModels.Calculations.QcRc;
using Business.BusinessModels.DataForCalculations;
using Business.DTO.Models.General;
using Business.DTO.Models.QcRc;
using Business.Interfaces;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.BaseCalculations.Consumption;
using Business.Interfaces.Calculations;
using Business.Interfaces.Calculations.ConsGasQn;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Tests.Calculations.Entities.ConsumptionGas
{
   public class Kc2
   {
      private Mock<IQcRc> MockQcRc;
      private Mock<IConsGasQn<ConsGasQn4000>> MockConsGasQn4000;
      private Mock<ICalcQcRc<QcRcKc2>> MockQcRcKc2;
      private Mock<ICalcConsGasQnKc2> Target;
      public Kc2()
      {
         MockQcRc = SetupHelper.QcRcSetup();
         MockConsGasQn4000 = SetupHelper.Qn4000Setup();
         QcRcKc2Setup();
         ConsQnKc2Setup();
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
         var consqnKc2 = new CalcConsQnKc2(MockQcRcKc2.Object, MockConsGasQn4000.Object);

         Target = new Mock<ICalcConsGasQnKc2>();
         Target.Setup(p => p.Calc(It.IsAny<QcRcData>()))
            .Returns((QcRcData data) =>
            consqnKc2.Calc(data));
      }
      private CbKc ExpectedObject()
      {
         return new CbKc
         {
            
            Cb1 = 155489.7759624722m,
            Cb2 = 152834.9430035578m,
            Cb3 = 113395.6054624054m,
            Cb4 = 122950.6159980599m,
         };
      }

      [Fact]
      public void ConsGasKc2()
      {
         var Data = new QcRcKgData
         {
            CharacteristicsKg = TestDataHelper.CharacteristicsKgData(),
            Kip = TestDataHelper.DevicesKipData(),
            WetGas = TestDataHelper.DensityDTOData(),
         };

         var expected = JsonConvert.SerializeObject(ExpectedObject());

         var result = JsonConvert.SerializeObject(Target.Object.Calc(Data));

         Assert.Equal(expected, result);
      }
   }
}
