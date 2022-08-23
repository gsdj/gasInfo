using BLL.Calculations.Entities.QcRc;
using BLL.DataHelpers;
using BLL.Interfaces.BaseCalculations;
using BLL.Interfaces.Calculations;
using BLL.Models.BaseModels.QcRc;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Tests.Calculations.Entities.QcRc
{
   public class Kc1
   {
      private Mock<IQcRc> MockQcRc;
      private Mock<ICalcQcRc<QcRcKc1>> Target;
      public Kc1()
      {
         MockQcRc = SetupHelper.DefaultQcRcSetup();
         QcRcKc1Setup();
      }
      private void QcRcKc1Setup()
      {
         Target = new Mock<ICalcQcRc<QcRcKc1>>();

         var qcrcKc1Calc = new CalcQcRcKc1(MockQcRc.Object);

         Target.Setup(p => p.Calc(It.IsAny<QcRcData>()))
            .Returns((QcRcData data) =>
            qcrcKc1Calc.Calc(data));
      }
      private QcRcKc1 ExpectedObject()
      {
         return new QcRcKc1
         {
            Cb1 =
            {
               Value = 890814.5442797562m,
            },
            Cb2 =
            {
               Value = 1023709.6082483867m,
            },
            Cb3 =
            {
               Value = 0.0m,
            },
            Cb4 =
            {
               Value = 1037536.7819241509m,
            },
         };
      }
      [Fact]
      public void QcRcKc1Default ()
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
