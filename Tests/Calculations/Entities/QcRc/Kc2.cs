using Business.BusinessModels.BaseCalculations;
using Business.BusinessModels.Calculations.QcRc;
using Business.BusinessModels.DataForCalculations;
using Business.DTO.Models.QcRc;
using Business.Interfaces;
using Business.Interfaces.BaseCalculations;
using Business.Interfaces.Calculations;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Tests.Calculations.Entities.QcRc
{
   public class Kc2
   {
      private Mock<IQcRc> MockQcRc;
      private Mock<ICalcQcRc<QcRcKc2>> Target;
      public Kc2()
      {
         MockQcRc = SetupHelper.QcRcSetup();
         QcRcKc2Setup();
      }
      private void QcRcKc2Setup()
      {
         Target = new Mock<ICalcQcRc<QcRcKc2>>();

         var qcrcKc1Calc = new CalcQcRcKc2(MockQcRc.Object);

         Target.Setup(p => p.Calc(It.IsAny<QcRcData>()))
            .Returns((QcRcData data) =>
            qcrcKc1Calc.Calc(data));
      }
      private QcRcKc2 ExpectedObject()
      {
         return new QcRcKc2
         {
            Cb1 =
            {
               Value = 172766.4177360802m,
            },
            Cb2 =
            {
               Value = 169816.6033372864m,
            },
            Cb3 =
            {
               Ms = 2482.9866551005m,
               Ks = 2480.0563010622m,
               Value = 119113.0309479048m,
            },
            Cb4 =
            {
               Ms = 2477.1255244498m,
               Ks = 2904.1164222440m,
               Value = 129149.8067206512m,
            },
         };
      }
      [Fact]
      public void QcRcKc2Default ()
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
