using BLL.Calculations.Base.Qn;
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
   public class Kc2
   {
      private Mock<IQcRc> MockQcRc;
      private Mock<IConsGasQn<ConsGasQn4000>> MockConsGasQn4000;
      private Mock<ICalcQcRc<QcRcKc2>> MockQcRcKc2;
      private Mock<ICalcConsGasQnKc2> Target;
      public Kc2()
      {
         MockQcRc = SetupHelper.DefaultQcRcSetup();
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
            CharacteristicsKg = TestCalculatedDataHelper.CharacteristicsKgData(),
            Kip = TestCalculatedDataHelper.DevicesKipData(),
            WetGas = TestCalculatedDataHelper.DensityDTOData(),
         };

         var expected = JsonConvert.SerializeObject(ExpectedObject());

         var result = JsonConvert.SerializeObject(Target.Object.Calc(Data));

         Assert.Equal(expected, result);
      }
   }
}
